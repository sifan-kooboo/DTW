using System.Collections.Generic;
using System.Text;
using System.IO;
using System;
using System.IO.Compression;

namespace Hotel_app.Server.updateclinet
{
    /// <summary>
    /// GZip压缩
    /// </summary>
    /// <remarks>
    /// 针对文件(夹)压缩，每个文件对应一个GZipUnit，最后对GZipUnit编码
    /// 格式化算法：[FileNameLength][FileName][ContentLength][Content]...
    ///             |<------1----->|          |<-----4----->|
    /// </remarks>
    public class GZipCompresser
    {
        #region 常量

        /// <summary>
        /// 解压缩最大单元长度
        /// </summary>
        public const int MaxUnitLength = 4096;
        /// <summary>
        /// 默认扩展名
        /// </summary>
        public const string DefaultExtension = ".gz";

        #endregion

        #region 公开方法

        /// <summary>
        /// 对目标文件(夹)进行压缩，将压缩结果保存为指定文件
        /// </summary>
        /// <param name="path">目标文件(夹)</param>
        /// <param name="zipFile">压缩文件名</param>
        public static void Compress(string path, string zipFile)
        {
            if (File.Exists(path))
            {
                List<GZipUnit> units = new List<GZipUnit> ();
                {
                    new GZipUnit(Path.GetFileName(path), File.ReadAllBytes(path));
                }
                EncodeAndCompress(zipFile, units);
            }
            else if (Directory.Exists(path))
            {
                List<GZipUnit> units = Prepare(path, Path.GetDirectoryName(path));
                EncodeAndCompress(zipFile, units);
            }
            else
                throw new FileNotFoundException("Not Found", path);
        }

        /// <summary>
        /// 对同目录下的多个文件进行压缩，将压缩结果保存为指定文件
        /// </summary>
        /// <param name="fileNames">文件名数组</param>
        /// <param name="zipFile">压缩文件名</param>
        public static void Compress(string[] fileNames, string zipFile)
        {
            if (fileNames != null)
            {
                List<GZipUnit> units = new List<GZipUnit>();
                foreach (string  fn in fileNames)
                {
                    units.Add(new GZipUnit(Path.GetFileName(fn), File.ReadAllBytes(fn)));
                }
                EncodeAndCompress(zipFile, units);
            }
        }

        /// <summary>
        /// 压缩字节数组
        /// </summary>
        /// <param name="buffer">待压缩的字节数组</param>
        /// <returns></returns>
        public static byte[] Compress(byte[] buffer)
        {
            return Compress(new MemoryStream(buffer));
        }

        /// <summary>
        /// 压缩流
        /// </summary>
        /// <param name="stream">待压缩的流</param>
        /// <returns></returns>
        public static byte[] Compress(Stream stream)
        {
            using (MemoryStream destination = new MemoryStream())
            {
                using (GZipStream output = new GZipStream(destination, CompressionMode.Compress, true))
                {
                    byte[] bytes = new byte[MaxUnitLength];
                    int n;
                    while ((n = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        output.Write(bytes, 0, n);
                    }
                    //必须先关闭，因为GZipStream是在Dispose的时候把数据完全写入
                    output.Close();
                    return destination.ToArray();
                }
            }
        }

        /// <summary>
        /// 对目标压缩文件解压缩，将内容解压缩到指定文件夹
        /// </summary>
        /// <param name="zipFile">压缩文件</param>
        /// <param name="dirPath">解压缩目录</param>
        public static void Decompress(string zipFile, string dirPath)
        {
            //解压
            byte[] buffer = Decompress(zipFile);
            //解码并创建文件
            DecodeAndCreateFile(buffer, dirPath);
        }

        /// <summary>
        /// 解压获取二进制内容
        /// </summary>
        /// <param name="buffer">解压前二进制内容</param>
        /// <returns></returns>
        public static byte[] Decompress(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("not found", fileName);
            }
            return Decompress(File.ReadAllBytes(fileName));
        }

        /// <summary>
        /// 解压获取二进制内容
        /// </summary>
        /// <param name="buffer">解压前二进制内容</param>
        /// <returns></returns>
        public static byte[] Decompress(byte[] buffer)
        {
            if (buffer == null)
                return null;
            using (Stream destination = new MemoryStream(buffer))
            {
                List<byte> result = new List<byte>();
                using (GZipStream input = new GZipStream(destination, CompressionMode.Decompress, true))
                {
                    byte[] bytes = new byte[MaxUnitLength];
                    int n;
                    while ((n = input.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        if (n == bytes.Length)
                        {
                            result.AddRange(bytes);
                        }
                        else
                        {
                            for (int i = 0; i < n; ++i)
                            {
                                result.Add(bytes[i]);
                            }
                        }
                    }
                }

                return result.ToArray();
            }
        }

        #endregion 公开方法

        #region 私有方法

        /// <summary>
        /// 准备压缩
        /// </summary>
        /// <param name="dirpath"></param>
        /// <param name="basePath"></param>
        /// <returns></returns>
        private static List<GZipUnit> Prepare(string dirpath, string basePath)
        {
            List<GZipUnit> units = new List<GZipUnit>();
            Prepare(units, dirpath, basePath);
            return units;
        }

        /// <summary>
        /// 准备压缩
        /// </summary>
        /// <param name="units"></param>
        /// <param name="dirPath"></param>
        /// <param name="basePath"></param>
        private static void Prepare(List<GZipUnit> units, string dirPath, string basePath)
        {
            foreach (string file in Directory.GetFiles(dirPath))
            {
                byte[] destBuffer = File.ReadAllBytes(file);
                string relativeFileName = file.Replace(basePath, string.Empty);

                while (relativeFileName.StartsWith(Path.DirectorySeparatorChar.ToString()))
                {
                    relativeFileName = relativeFileName.Remove(0, 1);
                }
                GZipUnit gzipUnit = new GZipUnit(relativeFileName, destBuffer);
                units.Add(gzipUnit);
            }
            foreach (string dir in Directory.GetDirectories(dirPath))
            {
                Prepare(units, dir, basePath);
            }
        }

        /// <summary>
        /// 修正压缩文件名
        /// </summary>
        /// <param name="zipFile">压缩文件名</param>
        private static void FixZipFile(ref string zipFile)
        {
            if (string.IsNullOrEmpty(Path.GetExtension(zipFile)))
            {
                zipFile += DefaultExtension;
            }
        }

        /// <summary>
        /// 编码并压缩
        /// </summary>
        /// <param name="zipFile">压缩文件名</param>
        /// <param name="units">GZip单元集合</param>
        private static void EncodeAndCompress(string zipFile, List<GZipUnit> units)
        {
            FixZipFile(ref zipFile);
            using (Stream stream = new MemoryStream())
            {
                byte[] content = Encode(units);
                stream.Write(content, 0, content.Length);
                stream.Position = 0;
                CreateCompressFile(stream, zipFile);
            }
        }

        /// <summary>
        /// GZip单元编码
        /// </summary>
        /// <param name="units">GZip单元集合</param>
        /// <returns></returns>
        private static byte[] Encode(List<GZipUnit> units)
        {
            if (units == null || units.Count == 0)
                return new byte[0];
            List<byte> result = new List<byte>();
            foreach (GZipUnit unit in units)
            {
                byte[] fn = Encoding.Default.GetBytes(unit.FileName);
                int fnLength = fn.Length;
                if (fnLength > 255)
                    throw new ArgumentException(string.Format("file name[{0}] is too long, max length is 255", unit.FileName));

                //文件名长度
                result.Add((byte)fnLength);
                //文件名
                result.AddRange(fn);
                //内容长度
                result.AddRange(UInt32ToBytes((UInt32)unit.Buffer.Length));
                //内容
                result.AddRange(unit.Buffer);
            }
            return result.ToArray();
        }

        /// <summary>
        /// GZip单元解码
        /// </summary>
        /// <param name="buffer">解压后的二进制数组</param>
        /// <returns></returns>
        private static List<GZipUnit> Decode(byte[] buffer)
        {
            List<GZipUnit> result = new List<GZipUnit>();
            for (int i = 0; i < buffer.Length; )
            {
                //文件名长度
                byte fnLen = buffer[i];
                //文件名
                byte[] fnBytes = GetSubBytes(buffer, i + 1, fnLen);
                string fileName = Encoding.Default.GetString(fnBytes);

                //内容长度
                UInt32 cLen = BytesToUInt32(GetSubBytes(buffer, i + 1 + fnLen, 4));
                //内容
                byte[] cBytes = GetSubBytes(buffer, i + fnLen + 5, (int)cLen);

                GZipUnit unit = new GZipUnit(fileName, cBytes);
                result.Add(unit);
                i += (fnLen + 5 + (int)cLen);
            }
            return result;
        }

        /// <summary>
        /// 解码并创建文件
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="dirPath"></param>
        private static void DecodeAndCreateFile(byte[] buffer, string dirPath)
        {
            List<GZipUnit> units = Decode(buffer);
            foreach (GZipUnit unit in units)
            {
                string newName = Path.Combine(dirPath, unit.FileName);
                string dir = Path.GetDirectoryName(newName);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                using (FileStream fs = new FileStream(newName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(unit.Buffer, 0, unit.Buffer.Length);
                    fs.Close();
                }
            }
        }

        /// <summary>
        /// 创建压缩文件
        /// </summary>
        /// <param name="source">待压缩流</param>
        /// <param name="destinationName">压缩文件</param>
        private static void CreateCompressFile(Stream source, string destinationName)
        {
            //压缩
            byte[] buffer = Compress(source);
            //写文件
            File.WriteAllBytes(destinationName, buffer);
        }

        /// <summary>
        /// 将无符号32位整数，转换成byte[4]
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private static Byte[] UInt32ToBytes(UInt32 val)
        {
            Byte[] result = new Byte[4];
            result[3] = Convert.ToByte(val % 256);
            val /= 256;
            result[2] = Convert.ToByte(val % 256);
            val /= 256;
            result[1] = Convert.ToByte(val % 256);
            val /= 256;
            result[0] = Convert.ToByte(val % 256);
            return result;
        }

        /// <summary>
        /// 将 byte[4] 转换成 无符号32位整数
        /// </summary>
        /// <param name="val">待转换的 byte[4]</param>
        /// <returns>转换成的 无符号32位整数</returns>
        private static UInt32 BytesToUInt32(Byte[] val)
        {
            UInt32 result = Convert.ToUInt32(((int)val[0] << 24) + ((int)val[1] << 16) + ((int)val[2] << 8) + (int)val[3]);
            return result;
        }

        /// <summary>
        /// 获取字节数组子数组
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="startIndex">起始Index</param>
        /// <param name="length">长度</param>
        /// <returns></returns>
        private static byte[] GetSubBytes(byte[] bytes, int startIndex, int length)
        {
            if (startIndex > bytes.Length - 1)
                return null;
            List<byte> result = new List<byte>();
            for (int i = startIndex; i < bytes.Length && i < startIndex + length; i++)
            {
                result.Add(bytes[i]);
            }
            return result.ToArray();
        }

        #endregion 私有方法

        #region 内部辅助类

        /// <summary>
        /// GZip流单元
        /// </summary>
        [Serializable]
        private class GZipUnit
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="GZipUnit"/> class.
            /// </summary>
            /// <param name="name">The name.</param>
            /// <param name="buffer">The buffer.</param>
            public GZipUnit(string name, byte[] buffer)
            {
                _fileName = name;
                _buffer = buffer;
            }

            private string _fileName;
            /// <summary>
            /// Gets the name of the file.
            /// </summary>
            /// <value>The name of the file.</value>
            public string FileName
            {
                get { return _fileName; }
            }

            private byte[] _buffer;
            /// <summary>
            /// Gets the buffer.
            /// </summary>
            /// <value>The buffer.</value>
            public byte[] Buffer
            {
                get { return _buffer; }
            }
        }
        #endregion
    }
}
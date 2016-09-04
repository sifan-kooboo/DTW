@echo off
gacutil -u DevExpress.Data.v11.2
mkdir %windir%\assembly\GAC_MSIL\DevExpress.Data.v11.2\11.2.5.0_b88d1754d700e49a
copy Assembly\DevExpress.Data.v11.2.dll %windir%\assembly\GAC_MSIL\DevExpress.Data.v11.2\11.2.11.0__b88d1754d700e49a

gacutil -u DevExpress.Utils.v11.2
mkdir %windir%\assembly\GAC_MSIL\DevExpress.Utils.v11.2\11.2.5.0_b88d1754d700e49a
copy Assembly\DevExpress.Utils.v11.2.dll %windir%\assembly\GAC_MSIL\DevExpress.Utils.v11.2\11.2.5.0_b88d1754d700e49a


gacutil -u DevExpress.XtraEditors.v11.2
mkdir %windir%\assembly\GAC_MSIL\DevExpress.XtraEditors.v11.2\11.2.5.0_b88d1754d700e49a
copy Assembly\DevExpress.XtraEditors.v11.2.dll %windir%\assembly\GAC_MSIL\DevExpress.XtraEditors.v11.2\11.2.5.0_b88d1754d700e49a


gacutil -u DevExpress.XtraGrid.v11.2
mkdir %windir%\assembly\GAC_MSIL\DevExpress.XtraGrid.v11.2\11.2.5.0_b88d1754d700e49a
copy Assembly\DevExpress.XtraGrid.v11.2.dll %windir%\assembly\GAC_MSIL\DevExpress.XtraGrid.v11.2\11.2.5.0_b88d1754d700e49a

gacutil -u DevExpress.XtraLayout.v11.2
mkdir %windir%\assembly\GAC_MSIL\DevExpress.XtraLayout.v11.2\11.2.5.0_b88d1754d700e49a
copy Assembly\DevExpress.XtraLayout.v11.2.dll %windir%\assembly\GAC_MSIL\DevExpress.XtraLayout.v11.2\11.2.5.0_b88d1754d700e49a
echo 'OK'
pause 
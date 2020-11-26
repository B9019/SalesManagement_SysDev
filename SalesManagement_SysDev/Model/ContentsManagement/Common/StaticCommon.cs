//using SalesManagement_SysDev.Model.Entity;
//using System.Data.Entity;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity.Infrastructure;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;


//namespace SalesManagement_SysDev.Model.ContentsManagement.Common
//{
//    public static class StaticCommon
//    {
//        // ***** ログ関係
//        // データ取得（EntityFramework）
//        public static IEnumerable<OperationLog> GetOperationLogs()
//        {
//            using (var db = new SalesManagement_DevContext()) return db.OperationLogs.ToList();
//        }

//        // データ追加
//        public static void PostOperationLog(OperationLog regOperationLog)
//        {
//            using (var db = new SalesManagement_DevContext())
//            {
//                db.OperationLogs.Add(regOperationLog);
//                db.SaveChanges();
//            }

//            // ファイル書出
//            WriteLog(regOperationLog);
//        }

//        // データ更新
//        public static void PutOperationLog(OperationLog regOperationLog)
//        {
//            using (var db = new SalesManagement_DevContext())
//            {
//                OperationLog operationLog;
//                try
//                {
//                    operationLog = db.OperationLogs.Single(m => m.OperationLogId == regOperationLog.OperationLogId);
//                }
//                catch (Exception ex)
//                {
//                    throw new Exception(Messages.errorNotFoundLog, ex);
//                    // throw new Exception(_cm.GetMessage(106), ex);
//                }
//                operationLog.EventRaisingTime = regOperationLog.EventRaisingTime;
//                operationLog.Operator = regOperationLog.Operator;
//                operationLog.Table = regOperationLog.Table;
//                operationLog.Command = regOperationLog.Command;
//                operationLog.Data = regOperationLog.Data;
//                operationLog.Comments = regOperationLog.Comments;
//                db.SaveChanges();
//            }
//        }

//        // データ削除
//        public static void DeleteOperationLog(int operationLogId)
//        {
//            using (var db = new SalesManagement_DevContext())
//            {
//                OperationLog operationLog;
//                try
//                {
//                    operationLog = db.OperationLogs.Single(x => x.OperationLogId == operationLogId);
//                }
//                catch (Exception ex)
//                {
//                    throw new Exception(Messages.errorNotFoundLog, ex);
//                    // throw new Exception(_cm.GetMessage(106), ex);
//                }
//                db.OperationLogs.Remove(operationLog);
//                try
//                {
//                    db.SaveChanges();
//                }
//                catch (DbUpdateConcurrencyException ex)
//                {
//                    throw new Exception(Messages.errorConflict, ex);
//                    // throw new Exception(_cm.GetMessage(100), ex);
//                }
//            }
//        }

//        // ログファイル書出
//        public static void WriteLog(OperationLog regOperationLog)
//        {
//            // コントロールパネル初期化終了チェック
//            using (var db = new SalesManagement_DevContext()) if (db.ControlPanels.Count() == 0) return;

//            // カウンターインクリメント
//            long counter;
//            try
//            {
//                using (var db = new SalesManagement_DevContext())
//                {
//                    CodeCounter codeCounter = db.CodeCounters.Single(m => m.CodeId == Constants.logCount);
//                    codeCounter.Counter++;
//                    counter = codeCounter.Counter;
//                    db.SaveChanges();
//                }
//            }
//            catch // (Exception ex)
//            {
//                return;
//                // throw new Exception(Messages.errorNotFoundCounter, ex);
//                // throw new Exception(_cm.GetMessage(102), ex);
//            }

//            if (counter > Constants.pageSizeLogging)
//            {
//                MessageBox.Show(Messages.logSwitching);
//                // MessageBox.Show(_cm.GetMessage(95));

//                // Saveファイル名切替
//                using (var db = new SalesManagement_DevContext())
//                {
//                    ControlPanel controlPanel = db.ControlPanels.First();
//                    controlPanel.FileName = Constants.defaultPath + Constants.defaultFileHead + DateTime.Now.ToShortDateString().Replace('/', '_') + Constants.defaultFileExtent;
//                    db.SaveChanges();
//                }

//                // カウンター初期化
//                try
//                {
//                    using (var db = new SalesManagement_DevContext())
//                    {
//                        CodeCounter codeCounter = db.CodeCounters.Single(m => m.CodeId == Constants.logCount);
//                        codeCounter.Counter = 1;
//                        db.SaveChanges();
//                    }
//                }
//                catch (Exception ex)
//                {
//                    throw new Exception(Messages.errorNotFoundCounter, ex);
//                    // throw new Exception(_cm.GetMessage(102), ex);
//                }
//            }

//            string data = string.Empty;
//            data += counter.ToString("0000");
//            data += regOperationLog.EventRaisingTime.ToShortDateString() + ":" + regOperationLog.EventRaisingTime.ToShortTimeString() + ",";
//            data += regOperationLog.Operator + ",";
//            data += regOperationLog.Command + ",";
//            data += regOperationLog.Data + "\r\n";

//            //using (var db = new SalesManagement_DevContext())
//            {
//                string path = db.ControlPanels.First().FileName;
//                File.AppendAllText(path, data);
//            }
//        }

//        // ログデータ作成（コントロールパネル）
//        // in       regControlPanel : ログ対象データ
//        public static string ControlPanelLogData(ControlPanel regControlPanel)
//        {
//            return regControlPanel.ControlPanelId.ToString() + ", " +
//            regControlPanel.FileName.ToString() + ", " +
//            regControlPanel.PageSize + ", " +
//            regControlPanel.LockSttRecord + ", " +
//            regControlPanel.LockEndRecord + ", " +
//            ConvertToString(1, regControlPanel.Status);
//        }

//        // ログデータ作成（Salt）
//        // in       egSalt : ログ対象データ
//        public static string SaltLogData(Salt regSalt)
//        {
//            return regSalt.SaltId.ToString() + ", " +
//            regSalt.SaltCode.ToString() + ", " +
//            System.Text.Encoding.UTF8.GetString(regSalt.SaltData) + ", " +
//            ConvertToString(1, regSalt.Status);
//        }

//        // ログデータ作成（ColumnsManagement）
//        // in       regColumnsManagement : ログ対象データ
//        public static string ColumnsManagementLogData(ColumnsManagement regColumnsManagement)
//        {
//            return regColumnsManagement.ColumnsManagementId.ToString() + ", " +
//            regColumnsManagement.ColumnsManagementCode.ToString() + ", " +
//            ConvertToString(2, regColumnsManagement.DisplayOrPrint) + ", " +
//            regColumnsManagement.ClassNumber.ToString() + ", " +
//            regColumnsManagement.ColumnNumber.ToString() + ", " +
//            regColumnsManagement.HeaderName + ", " +
//            regColumnsManagement.Visible.ToString() + ", " +
//            regColumnsManagement.ColumnWidth.ToString() + ", " +
//            ConvertToString(4, regColumnsManagement.BackColor) + ", " +
//            regColumnsManagement.CharMaxLength.ToString() + ", " +
//            ConvertToString(8, regColumnsManagement.CharLayout) + ", " +
//            regColumnsManagement.WrapMode.ToString() + ", " +
//            ConvertToString(6, regColumnsManagement.FontFamily) + ", " +
//            regColumnsManagement.FontSize.ToString() + ", " +
//            regColumnsManagement.Bold.ToString() + ", " +
//            ConvertToString(5, regColumnsManagement.ForeColor) + ", " +
//            ConvertToString(1, regColumnsManagement.Status);
//        }

//        // ***** その他

//        // コード→文字列変換
//        // mode
//        // 0    : AccessAuth
//        // 1    : Status
//        // 2    : DisplayOrPrint
//        // 3    : Bold
//        // 4    : BackColor
//        // 5    : ForeColor
//        // 6    : FontFamily
//        // 7    : Entity
//        // 8    : Layout
//        // 9    : LockInfo
//        //10    : StockInfo
//        //11    : StockManagement
//        public static string ConvertToString(int mode, int sw)
//        {
//            switch (mode)
//            {
//                case 0:
//                    switch (sw)
//                    {
//                        case 0:
//                            return Constants.strGeneral;
//                        case 1:
//                            return Constants.strManager;
//                        case 2:
//                            return Constants.strMaster;
//                    }
//                    return string.Empty;
//                case 1:
//                    switch (sw)
//                    {
//                        case 0:
//                            return Constants.strStatus0;
//                        case 1:
//                            return Constants.strStatus1;
//                        case 2:
//                            return Constants.strStatus2;
//                        case 3:
//                            return Constants.strStatus3;
//                        case 4:
//                            return Constants.strStatus4;
//                        case 5:
//                            return Constants.strStatus5;
//                        case 6:
//                            return Constants.strStatus6;
//                        case 7:
//                            return Constants.strStatus7;
//                        case 8:
//                            return Constants.strStatus8;
//                        case 9:
//                            return Constants.strStatus9;
//                    }
//                    return string.Empty;
//                case 2:
//                    switch (sw)
//                    {
//                        case 0:
//                            return Constants.strDisplay;
//                        case 1:
//                            return Constants.strPrint;
//                    }
//                    return string.Empty;
//                case 3:
//                    switch (sw)
//                    {
//                        case 0:
//                            return Constants.strStanderd;
//                        case 1:
//                            return Constants.strBold;
//                    }
//                    return string.Empty;
//                case 4:
//                    switch (sw)
//                    {
//                        case 0:
//                            return Constants.clrWhite;
//                        case 1:
//                            return Constants.clrIvory;
//                        case 2:
//                            return Constants.clrLightYellow;
//                        case 3:
//                            return Constants.clrLightGray;
//                        case 4:
//                            return Constants.clrLightPink;
//                        case 5:
//                            return Constants.clrLightBlue;
//                        case 6:
//                            return Constants.clrAquamarine;
//                        case 7:
//                            return Constants.clrLightSkyBlue;
//                        case 8:
//                            return Constants.clrSkyBlue;
//                        case 9:
//                            return Constants.clrPaleGreen;
//                        case 10:
//                            return Constants.clrLightSalmon;
//                        case 11:
//                            return Constants.clrLightGreen;
//                    }
//                    return string.Empty;
//                case 5:
//                    switch (sw)
//                    {
//                        case 0:
//                            return Constants.clrBlack;
//                        case 1:
//                            return Constants.clrPink;
//                        case 2:
//                            return Constants.clrViolet;
//                        case 3:
//                            return Constants.clrSilver;
//                        case 4:
//                            return Constants.clrYellow;
//                        case 5:
//                            return Constants.clrGold;
//                        case 6:
//                            return Constants.clrOrange;
//                        case 7:
//                            return Constants.clrGray;
//                        case 8:
//                            return Constants.clrOlive;
//                        case 9:
//                            return Constants.clrPurple;
//                        case 10:
//                            return Constants.clrBlue;
//                        case 11:
//                            return Constants.clrLime;
//                        case 12:
//                            return Constants.clrRed;
//                        case 13:
//                            return Constants.clrMaroon;
//                        case 14:
//                            return Constants.clrBrown;
//                        case 15:
//                            return Constants.clrNavy;
//                        case 16:
//                            return Constants.clrGreen;
//                        case 17:
//                            return Constants.clrDarkGreen;
//                    }
//                    return string.Empty;
//                case 6:
//                    switch (sw)
//                    {
//                        case 0:
//                            return Constants.fontSystem;
//                        case 1:
//                            return Constants.fontMsGothic;
//                        case 2:
//                            return Constants.fontMsMincho;
//                        case 3:
//                            return Constants.fontMspGothic;
//                        case 4:
//                            return Constants.fontMspMincho;
//                        case 5:
//                            return Constants.fontMeirio;
//                        case 6:
//                            return Constants.fontSansSerif;
//                        case 7:
//                            return Constants.fontArial;
//                        case 8:
//                            return Constants.fontCenturyGothic;
//                        case 9:
//                            return Constants.fontSerif;
//                    }
//                    return string.Empty;
//                case 7:
//                    switch (sw)
//                    {
//                        case 0:
//                            return Constants.strShop;
//                        case 1:
//                            return Constants.strDivision;
//                        case 2:
//                            return Constants.strStaff;
//                        case 3:
//                            return Constants.strCategory;
//                        case 4:
//                            return Constants.strMaker;
//                        case 5:
//                            return Constants.strTax;
//                        case 6:
//                            return Constants.strUnit;
//                        case 7:
//                            return Constants.strItem;
//                        case 8:
//                            return Constants.strSupplier;
//                        case 9:
//                            return Constants.strColumnsManagement;
//                        case 10:
//                            return Constants.strSale;
//                        case 11:
//                            return Constants.strStock;
//                        case 12:
//                            return Constants.strOrder;
//                        case 13:
//                            return Constants.strAggregation;
//                        case 14:
//                            return Constants.strOrdering;
//                        case 15:
//                            return Constants.strLog;
//                    }
//                    return string.Empty;
//                case 8:
//                    switch (sw)
//                    {
//                        case 0:
//                            return Constants.strLayoutLeft;
//                        case 1:
//                            return Constants.strLayoutRight;
//                        case 2:
//                            return Constants.strLayoutCenter;
//                    }
//                    return string.Empty;
//                case 9:
//                    switch (sw)
//                    {
//                        case 0:
//                            return Constants.infoUnlock;
//                        case 1:
//                            return Constants.infoLock;
//                    }
//                    return string.Empty;
//                case 10:
//                    switch (sw)
//                    {
//                        case 0:
//                            return Constants.infoStockUnManaged;
//                        case 1:
//                            return Constants.infoStockManaged;
//                    }
//                    return string.Empty;
//                case 11:
//                    switch (sw)
//                    {
//                        case 0:
//                            return Constants.actionReceiving;
//                        case 1:
//                            return Constants.actionIssuing;
//                        case 2:
//                            return Constants.actionMoving;
//                        case 3:
//                            return Constants.actionInventoryReceiving;
//                        case 4:
//                            return Constants.actionInventoryIssuing;
//                    }
//                    return string.Empty;

//                default:
//                    return string.Empty;
//            }
//        }

//    }

//}

using SalesManagement.Model.ContentsManagement;
using SalesManagement.Model.ContentsManagement.Common;
using System;
using System.Text;
using System.Text.RegularExpressions;



namespace SalesManagement.Model
{
    class InputCheck
    {
        // データベース処理モジュール
        private readonly CommonFunction _cm = new CommonFunction();

        // データベース処理モジュール（Staff）
        private readonly StaffContents _st = new StaffContents();

        // *** 複合機能チェック *****

        // 空白レス全角文字チェック
        // in   : text = 入力文字列
        // out  : true = チェックOK
        //      : errorMessage = チェックNG　エラーメッセージ
        public bool SpacelessFullWidthCharCheck(string text, out string errorMessage)
        {
            bool result = false;

            // スペースチェック
            if (!SpaceCheck(text, out errorMessage)) return result;

            // 全角チェック
            if (!FullWidthCharCheck(text, out errorMessage)) return result;

            return true;
        }

        // 空白レス全角カタカナチェック
        // in   : text = 入力文字列
        // out  : true = チェックOK
        //      : errorMessage = チェックNG　エラーメッセージ
        public bool SpacelessFullWidthKatakanaCheck(string text, out string errorMessage)
        {
            bool result = false;

            // スペースチェック
            if (!SpaceCheck(text, out errorMessage)) return result;

            // 全角カタカナチェック
            if (!FullWidthKatakanaCheck(text, out errorMessage)) return result;

            return true;
        }

        // 数値範囲チェック
        // in   : text = 入力文字列
        //      : min = 最小数値
        //      : max = 最大数値
        // out  : true = チェックOK
        //      : errorMessage = チェックNG　エラーメッセージ
        public bool NumericRangeCheck(string text, long min, long max, out string errorMessage)
        {
            if (!IntegerCheck(text, out errorMessage)) return false;

            long checkNum = long.Parse(text);
            if (min <= checkNum && checkNum <= max) return true;

            errorMessage = string.Format("{0}～{1}の範囲の数値で入力して下さい。", min, max);
            return false;
        }

        // *** 単機能チェック *****

        // 空白チェック
        // in   : text = 入力文字列
        // out  : true = チェックOK
        //      : errorMessage = チェックNG　エラーメッセージ
        public bool SpaceCheck(string text, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool result = false;

            Regex regex = new Regex(@"\s+");
            if (regex.IsMatch(text))
                errorMessage = "空白は入力しないでください。";
            else
                result = true;
            return result;
        }

        // 数値チェック
        // in   : text = 入力文字列
        // out  : true = チェックOK
        //      : errorMessage = チェックNG　エラーメッセージ
        public bool NumericCheck(string text, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool result = false;

            Regex regex = new Regex("^[0-9]+$");
            if (!regex.IsMatch(text))
                errorMessage = "数値のみ入力してください。";
            else
                result = true;
            return result;
        }

        // 整数チェック
        // in   : text = 入力文字列
        // out  : true = チェックOK
        //      : errorMessage = チェックNG　エラーメッセージ
        public bool IntegerCheck(string text, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool result = false;

            Regex regex = new Regex("^-?[0-9]+$");
            if (!regex.IsMatch(text))
                errorMessage = "整数のみ入力してください。";
            else
                result = true;
            return result;
        }

        // 自然数チェック
        // in   : text = 入力文字列
        // out  : true = チェックOK
        //      : errorMessage = チェックNG　エラーメッセージ
        public bool NatureNumberCheck(string text, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool result = false;

            Regex regex = new Regex("^[1-9][0-9]*$");
            if (!regex.IsMatch(text))
                errorMessage = "自然数のみ入力してください。";
            else
                result = true;
            return result;
        }

        // 値段チェック
        // in   : text = 入力文字列
        // out  : true = チェックOK
        //      : errorMessage = チェックNG　エラーメッセージ
        public bool PriceCheck(string text, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool result = false;

            Regex regex = new Regex(@"^(0|([1-9](\d{0,2})((,\d{3}){0,2})))$");
            if (!regex.IsMatch(text))
                errorMessage = "カンマ付き数値で入力して下さい。";
            else
            {
                // 値段範囲チェック
                int price = int.Parse((text != string.Empty) ? text.Replace(",", "") : "0");
                if (0 <= price && price <= Constants.priceMax) result = true;
            }
            return result;
        }

        // 半角英字チェック
        // in   : text = 入力文字列
        // out  : true = チェックOK
        //      : errorMessage = チェックNG　エラーメッセージ
        public bool HalfAlphabetCheck(string text, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool result = false;

            Regex regex = new Regex("^[a-zA-Z]+$");
            if (!regex.IsMatch(text))
                errorMessage = "半角英字のみ入力してください。";
            else
                result = true;
            return result;
        }

        // 半角英数字チェック
        // in   : text = 入力文字列
        // out  : true = チェックOK
        //      : errorMessage = チェックNG　エラーメッセージ
        public bool HalfAlphabetNumericCheck(string text, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool result = false;

            Regex regex = new Regex("^[a-zA-Z0-9]+$");
            if (!regex.IsMatch(text))
                errorMessage = "半角英数字のみ入力してください。";
            else
                result = true;
            return result;
        }

        // 半角英数記号チェック
        // in   : text = 入力文字列
        // out  : true = チェックOK
        //      : errorMessage = チェックNG　エラーメッセージ
        public bool HalfCharCheck(string text, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool result = false;

            Regex regex = new Regex("^[ -~]+$");
            if (!regex.IsMatch(text))
                errorMessage = "半角英数記号のみ入力してください。";
            else
                result = true;
            return result;
        }

        // 半角英数記号チェック（パスワードチェック用スペシャル）
        // in   : text = 入力文字列
        // out  : true = チェックOK
        //      : errorMessage = チェックNG　エラーメッセージ
        public bool HalfCharSpecialSymbolCheck(string text, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool result = false;

            Regex regex = new Regex(@"^[a-zA-Z0-9!#$%&'()*+,-./:;<=>?@[\]^_{|}~]+$");
            if (!regex.IsMatch(text))
                errorMessage = @"半角英数記号（!#$%&'()*+,-./:;<=>?@[\]^_{|}~）のみ入力してください。";
            else
                result = true;
            return result;
        }

        // 全角チェック
        // in   : text = 入力文字列
        // out  : true = チェックOK
        //      : errorMessage = チェックNG　エラーメッセージ
        public bool FullWidthCharCheck(string text, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool result = false;

            int textLength = text.Replace("\r\n", string.Empty).Length;
            int textByte = Encoding.GetEncoding("Shift_JIS").GetByteCount(text.Replace("\r\n", string.Empty));
            if (textByte != textLength * 2)
                errorMessage = "全角で入力してください。";
            else
                result = true;
            return result;
        }

        // カタカナチェック
        // in   : text = 入力文字列
        // out  : true = チェックOK
        //      : errorMessage = チェックNG　エラーメッセージ
        public bool KatakanaCheck(string text, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool result = false;

            Regex regex = new Regex(@"[^\p{IsKatakana} 　-ー－]+$");
            if (!regex.IsMatch(text))
                errorMessage = "カタカナのみ入力してください。";
            else
                result = true;
            return result;
        }

        // 全角カタカナチェック
        // in   : text = 入力文字列
        // out  : true = チェックOK
        //      : errorMessage = チェックNG　エラーメッセージ
        public bool FullWidthKatakanaCheck(string text, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool result = false;

            if (!Regex.IsMatch(text, @"^\p{IsKatakana}*$"))
                errorMessage = "全角カタカナのみ入力してください。";
            else
                result = true;
            return result;
        }

        // 半角カタカナチェック
        // in   : text = 入力文字列
        // out  : true = チェックOK
        //      : errorMessage = チェックNG　エラーメッセージ
        public bool HalfWidthKatakanaCheck(string text, out string qerrorMessage)
        {
            qerrorMessage = string.Empty;
            bool result = false;

            //Regex regex = new Regex("^[ -~｡-ﾟ]+$");
            Regex regex = new Regex(@"[\uFF66-\uFF9D]");
            if (!regex.IsMatch(text))
                qerrorMessage = "半角カタカナのみ入力してください。";
            else
                result = true;
            return result;
        }

        // ひらがなチェック
        // in   : text = 入力文字列
        // out  : true = チェックOK
        //      : errorMessage = チェックNG　エラーメッセージ
        public bool HiraganaCheck(string text, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool result = false;

            Regex regex = new Regex(@"^\p{IsHiragana}+$");
            if (!regex.IsMatch(text))
                errorMessage = "ひらがなのみ入力してください。";
            else
                result = true;
            return result;
        }

        // 電話番号チェック
        // in   : text = 入力文字列
        // out  : true = チェックOK
        //      : errorMessage = チェックNG　エラーメッセージ
        public bool PhoneNoCheck(string text, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool result = false;

            Regex regex = new Regex(@"^0\d{1,4}-\d{1,4}-\d{4}$");
            if (!regex.IsMatch(text))
                errorMessage = "例：半角数字〇〇-〇〇〇〇-〇〇〇〇の形式で入力してください。";
            else
                result = true;
            return result;
        }

        // 郵便番号チェック
        // in   : text = 入力文字列
        // out  : true = チェックOK
        //      : errorMessage = チェックNG　エラーメッセージ
        public bool PostNoCheck(string text, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool result = false;

            Regex regex = new Regex(@"^\d{3}-\d{4}$");
            if (!regex.IsMatch(text))
                errorMessage = "例：半角数字〇〇〇-〇〇〇〇の形式で入力してください。";
            else
                result = true;
            return result;
        }

        // メールアドレスチェック（複数記述対応）
        // in   : text = 入力文字列
        // out  : true = チェックOK
        //      : errorMessage = チェックNG　エラーメッセージ
        public bool MailAddressCheck(string text, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool result = false;

            Regex regex = new Regex(@"^\b[\w.%+-]+@[\w.-]+\.[a-zA-Z]{2,4}\b$");
            if (!regex.IsMatch(text))
                errorMessage = "認識できるメールアドレスの形式ではありません。";
            else
                result = true;
            return result;
        }

        // URLチェック
        // in   : text = 入力文字列
        // out  : true = チェックOK
        //      : errorMessage = チェックNG　エラーメッセージ
        public bool UrlCheck(string text, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool result = false;

            Regex regex = new Regex(@"^http(s)?://([\w-]+\.)+[\w.-]+\.[a-zA-Z]{2,4}$");
            if (!regex.IsMatch(text))
                errorMessage = "認識できるURLアドレスの形式ではありません。";
            else
                result = true;
            return result;
        }

        // 年月日チェック
        // in   : text = 入力文字列
        // out  : true = チェックOK
        //      : errorMessage = チェックNG　エラーメッセージ
        public bool DateFormCheck(string text, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                if (DateTime.Parse(Constants.sqlServerInitialDate) < DateTime.Parse(text) && DateTime.Parse(text) < DateTime.Parse(Constants.sqlServerInitialDate).AddYears(1000))
                {
                    return true;
                }
                errorMessage = "認識できる日付ではありません。";
                return false;
            }
            catch
            {
                errorMessage = "認識できる日付ではありません。";
                return false;
            }
        }

    }
}

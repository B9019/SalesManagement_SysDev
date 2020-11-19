using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SalesManagement.Model
{
    // ハッシュ処理クラス
    public class HashManagement
    {

        // SHA256
        // in   : string password
        //      : byte[] salt
        // out  : byte[] SHA256 HASH
        public byte[] CreateSha256PasswordHash(string password, byte[] salt)
        {
            var encoder = new UTF8Encoding();
            var bytePassword = encoder.GetBytes(password);
            var bytePasswordSalt = bytePassword.Concat(salt).ToArray();

            byte[] hash;
            using (var csp = new SHA256CryptoServiceProvider())
            {
                hash = csp.ComputeHash(bytePasswordSalt);
            }
            return hash;
        }

        // PBKDF2（Password-Based Key Drivation Function 2 RFC2898）
        // in   : string password
        //      : byte[] salt
        // out  : byte[] PBKDF2 HASH
        public byte[] CreatePBKDF2PasswordHash(string password, byte[] salt)
        {
            var hash = new Rfc2898DeriveBytes(password, salt, Constants.pbkdf2Iteration).GetBytes(32);
            return hash;
        }

        // Salt生成
        public byte[] GenerateSalt()
        {
            // ランダムデータ生成
            var salt = new byte[Constants.saltSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
    }
}

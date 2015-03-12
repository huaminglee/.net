
namespace dean.util {
    using System;

    public sealed class XXTEA {
        private const UInt32 delta = 0x9E3779B9;

        private XXTEA() {
        }

        public static Byte[] Encrypt(Byte[] data, Byte[] Key) {
            if (data.Length == 0) {
                return data;
            }
            return ToByteArray(Encrypt(ToUInt32Array(data, true), ToUInt32Array(Key, false)), false);
        }

        public static Byte[] Decrypt(Byte[] data, Byte[] Key) {
            if (data.Length == 0) {
                return data;
            }
            return ToByteArray(Decrypt(ToUInt32Array(data, false), ToUInt32Array(Key, false)), true);
        }

        private static UInt32[] Encrypt(UInt32[] v, UInt32[] k) {
            Int32 n = v.Length - 1;
            if (n < 1) {
                return v;
            }
            if (k.Length < 4) {
                UInt32[] Key = new UInt32[4];
                k.CopyTo(Key, 0);
                k = Key;
            }
            UInt32 z = v[n], y = v[0], sum = 0, e;
            Int32 p, q = 6 + 52 / (n + 1);
            unchecked {
                while (0 < q--) {
                    sum += delta;
                    e = sum >> 2 & 3;
                    for (p = 0; p < n; p++) {
                        y = v[p + 1];
                        z = v[p] += (z >> 5 ^ y << 2) + (y >> 3 ^ z << 4) ^ (sum ^ y) + (k[p & 3 ^ e] ^ z);
                    }
                    y = v[0];
                    z = v[n] += (z >> 5 ^ y << 2) + (y >> 3 ^ z << 4) ^ (sum ^ y) + (k[p & 3 ^ e] ^ z);
                }
            }
            return v;
        }

        private static UInt32[] Decrypt(UInt32[] v, UInt32[] k) {
            Int32 n = v.Length - 1;
            if (n < 1) {
                return v;
            }
            if (k.Length < 4) {
                UInt32[] Key = new UInt32[4];
                k.CopyTo(Key, 0);
                k = Key;
            }
            UInt32 z = v[n], y = v[0], sum, e;
            Int32 p, q = 6 + 52 / (n + 1);
            unchecked {
                sum = (UInt32)(q * delta);
                while (sum != 0) {
                    e = sum >> 2 & 3;
                    for (p = n; p > 0; p--) {
                        z = v[p - 1];
                        y = v[p] -= (z >> 5 ^ y << 2) + (y >> 3 ^ z << 4) ^ (sum ^ y) + (k[p & 3 ^ e] ^ z);
                    }
                    z = v[n];
                    y = v[0] -= (z >> 5 ^ y << 2) + (y >> 3 ^ z << 4) ^ (sum ^ y) + (k[p & 3 ^ e] ^ z);
                    sum -= delta;
                }
            }
            return v;
        }

        private static UInt32[] ToUInt32Array(Byte[] data, Boolean includeLength) {
            Int32 length = data.Length;
            Int32 n = (((length & 3) == 0) ? (length >> 2) : ((length >> 2) + 1));
            UInt32[] result;
            if (includeLength) {
                result = new UInt32[n + 1];
                result[n] = (UInt32)length;
            }
            else {
                result = new UInt32[n];
            }
            n = length;
            for (Int32 i = 0; i < n; i++) {
                result[i >> 2] |= (UInt32)data[i] << ((i & 3) << 3);
            }
            return result;
        }

        private static Byte[] ToByteArray(UInt32[] data, Boolean includeLength) {
            Int32 length = data.Length;
            Int32 n = length << 2;
            if (includeLength) {
                Int32 m = (Int32)data[length - 1];
                if (m > n) {
                    return null;
                }
                else {
                    n = m;
                }
            }
            Byte[] result = new Byte[n];
            for (Int32 i = 0; i < n; i++) {
                result[i] = (Byte)(data[i >> 2] >> ((i & 3) << 3));
            }
            return result;
        }

        #region "XXTEA¼ÓÃÜ×Ö·û´®"
        /// <summary>
        /// XXTEA¼ÓÃÜ×Ö·û´®
        /// </summary>
        /// <param name="encryptString"></param>
        /// <param name="encryptKey"></param>
        /// <returns></returns>
        public static string Encrypt(string encryptString, string encryptKey)
        {
            try
            {
                System.Text.Encoding encoder = System.Text.Encoding.UTF8;
                Byte[] data = XXTEA.Encrypt(encoder.GetBytes(encryptString), encoder.GetBytes(encryptKey));
                return System.Convert.ToBase64String(data);
            }
            catch
            {
                return encryptString;
            }
        }
        #endregion

        #region "XXTEA½âÃÜ×Ö·û´®"
        /// <summary>
        /// XXTEA½âÃÜ×Ö·û´®
        /// </summary>
        /// <param name="decryptString"></param>
        /// <param name="decryptKey"></param>
        /// <returns></returns>
        public static string Decrypt(string decryptString, string decryptKey)
        {
            try
            {
                System.Text.Encoding encoder = System.Text.Encoding.UTF8;
                return encoder.GetString(XXTEA.Decrypt(System.Convert.FromBase64String(decryptString), encoder.GetBytes(decryptKey)));
            }
            catch
            {
                return decryptString;
            }
        }

        #endregion

    }
}
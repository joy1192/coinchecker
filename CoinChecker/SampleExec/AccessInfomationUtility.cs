using System;
using System.Collections.Generic;
using System.Text;

namespace SampleExec
{
    public class AccessInfomationUtility
    {
        // 開発時点では環境変数の値を使用
        private const string EnvironmentVariableKeyName = "ACCESSKEY";
        private const string EnvironmentVariableSecretName = "SECRETACCESSKEY";

        /// <summary>
        /// Consumer Keyを取得します
        /// </summary>
        public static string GetAccessKey()
        {
            return Environment.GetEnvironmentVariable(EnvironmentVariableKeyName, EnvironmentVariableTarget.User);
        }

        /// <summary>
        /// Consumer Secretを取得します
        /// </summary>
        public static string GetSecretAccessKey()
        {
            return Environment.GetEnvironmentVariable(EnvironmentVariableSecretName, EnvironmentVariableTarget.User);
        }
    }
}

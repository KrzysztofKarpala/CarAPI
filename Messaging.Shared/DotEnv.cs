using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging.Shared
{
    public static class DotEnv
    {
        public static void Load(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return;
            }
            foreach (var line in File.ReadLines(filePath))
            {
                int index = line.IndexOf('=');
                if (index == -1)
                {
                    continue;
                }
                var name = line[..index];
                var value = line[(index + 1)..];
                Environment.SetEnvironmentVariable(name, value);
            }
        }
    }
}

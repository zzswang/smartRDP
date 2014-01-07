using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRDP
{
    public class RDPServer
    {
        private string passwordSalt = "woaimima";  // 安全起见，建议更改这个key，必须8位

        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }    
        public string Description { get; set; }
        public bool IsVNC { get; set; }

        public string PasswordWithSalt
        {
            get
            {
                return Security.EncryptDES(this.Password, this.passwordSalt);
            }
            set
            {
                this.Password = Security.DecryptDES(value, this.passwordSalt);
            }
        }

        public RDPServer() { }

        public RDPServer(string server, string username, string password)
        {
            this.Name = server;
            this.Username = username;
            this.Password = password;
        }

        // 不把密码序列化出去
        public bool ShouldSerializePassword()
        {
            return false;
        }

        public string getPassword()
        {
            return this.Password;
        }
    }
}

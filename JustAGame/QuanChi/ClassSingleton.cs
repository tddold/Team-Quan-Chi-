using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanChi
{
    public class ClassSingleton
    {
        private static ClassSingleton _instance = new ClassSingleton();
        public string PathPicture { get; set; }
        public static ClassSingleton get_instance()
        {
            return _instance;
        }
    }
}

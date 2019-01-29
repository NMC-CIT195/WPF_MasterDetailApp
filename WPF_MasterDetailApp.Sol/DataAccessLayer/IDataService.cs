using WPF_MasterDetailApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MasterDetailApp.DataAccessLayer
{
    public interface IDataService
    {
        List<Character> ReadAll();
        void WriteAll(List<Character> characters);
    }
}

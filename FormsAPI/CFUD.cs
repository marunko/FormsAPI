using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace FormsAPI
{
    interface CFUD
    {
        bool Create(string title, string body);

        DataSet Find(string title);

        bool Update();

        bool Delete();


    }
}

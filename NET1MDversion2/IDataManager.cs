using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET1MDversion2
{
    //8 UZD - viss uzdevums tika izstrādāts izmantojot AI rīka palīdzību
    public interface IDataManager
    {
        string print(); //samainiju uz string prieks 2md
        void save(string filePath = @"C:\Temp\schooldata.xml");
        void load(string filePath = @"C:\Temp\schooldata.xml");
        void createTestData();
        void reset();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _20T1080020.DomainModels;

namespace _20T1080020.DataLayers
{
    /// <summary>
    /// định nghĩa phép xử dữ liệu liên quan đến quốc gia
    /// </summary>
    public interface ICountryDAL
    {
        IList<Country> List();
    }
}

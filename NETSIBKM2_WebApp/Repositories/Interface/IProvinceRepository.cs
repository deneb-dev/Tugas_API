using NETSIBKM2_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETSIBKM2_WebApp.Repositories.Interface
{
    interface IProvinceRepository
    {   
        List<Province> Get();

        Province Get( int id ,Province province);

        
        int Post(Province province);

      
        int Put(int id, Province province);

      
        int Delete(Province province);
    }
}

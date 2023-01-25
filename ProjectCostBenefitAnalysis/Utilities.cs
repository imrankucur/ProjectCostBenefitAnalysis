using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace ProjectCostBenefitAnalysis
{
    public class Utilities
    {
        ProjectCostBenefitAnalysisEntities db = new ProjectCostBenefitAnalysisEntities();
        public static string EncryptPassword(string password) 
        {
            password= BCrypt.Net.BCrypt.HashPassword(password);

            return password;
        }
        
    }
}
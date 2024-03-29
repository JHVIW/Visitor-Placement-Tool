﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Interfaces
{
    public interface IBezoekerDAL
    {
        void CreateBezoeker(Bezoeker bezoeker);
        Bezoeker GetBezoekerById(int id);
        void UpdateBezoeker(Bezoeker bezoeker);
        void DeleteBezoeker(int id);
        List<Bezoeker> GetAllBezoekers();


    }
}

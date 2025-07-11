﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tvo.Infraestructura.AccesoDatos;

namespace tvo.Dominio.Modelo.Abstracciones
{
    public interface ICooperativeRepository : IRepository<cooperative>
    {
        Task<int> CountCooperativesByName(string nameCooperative);
    }
}

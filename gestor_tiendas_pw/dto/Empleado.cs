﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestor_tiendas_pw.dto
{
    public class Empleado
    {
        int id;
        string nombre, user, pass, tienda;
        public int getId
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
        public string getNombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }
        public string getuser
        {
            get
            {
                return this.user;
            }
            set
            {
                this.user = value;
            }
        }
        public string getPass
        {
            get
            {
                return this.pass;
            }
            set
            {
                this.pass = value;
            }
        }
        public  string getTienda
        {
            get
            {
                return this.tienda;
            }
            set
            {
                this.tienda = value;
            }
        }

    }
}
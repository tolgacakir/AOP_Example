using AOPExample.BusinessLogic;
using AOPExample.IoC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AOPExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var resolver = new AutofacDependencyResolver();
            var productService = resolver.GetService<IProductService>();


            //var b = productService.Create("tolga", "cakir");

            var a = productService.Get("a", "b");
            a = productService.AOP_Get("a", "b");
            int i = 0;

            //throw new Exception();
            //((ProductService)productService).Set("c", "d");
        }

    }
}

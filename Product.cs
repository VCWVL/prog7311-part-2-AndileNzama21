using System;
using System.Collections.Generic;

namespace PROG.Models;

 public class Product
 {
     public int ProductId { get; set; }
     public string Name { get; set; }
     public string Email { get; set; }
     public string Category { get; set; }
     public string DateTime  { get; set; }
     public int FarmerId { get; set; }
     public Farmer Farmer { get; set; }

     public DateTime ProductionDate { get; set; }

 }
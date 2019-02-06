using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SML.Models
{
  public class BigViewModel
  {
    public UserTable UserTable { get; set; }
    public List<SongTable> SongTable { get; set; }

  }
}
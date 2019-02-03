using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SML.Models.Extended
{
  [MetadataType(typeof(SongMetaData))]
  public class SongTable
  {
   
  }

  public class SongMetaData
  {
    [Required]
    public string SongName { get; set; }
    [Required]
    public string Lyrics { get; set; }
    [Required]
    public string Artist { get; set; }
  }
}
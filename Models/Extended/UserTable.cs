using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SML.Models.Extended
{
  [MetadataType(typeof(UserMetaData))]
  public partial class UserTable
  {


  }

  public class UserMetaData
  {

    [Required]
    public string UserName { get; set; }
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [MinLength(6)]
    public string Password { get; set; }

  }
}
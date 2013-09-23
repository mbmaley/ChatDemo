using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChatDemo.ViewModels.Chat
{
    public class SimpleViewModel
    {
        [Required(ErrorMessage = "You need to enter a nickname.")]
        [DisplayName("Nickname")]
        [MinLength(3, ErrorMessageResourceType = typeof(Resource1), ErrorMessageResourceName = "NicknameErrorMessage")]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "You need to enter a message.")]
        [DisplayName("Message")]
        [MinLength(1, ErrorMessageResourceType = typeof(Resource1), ErrorMessageResourceName = "NicknameErrorMessage")]
        public string Message { get; set; }
    }
}
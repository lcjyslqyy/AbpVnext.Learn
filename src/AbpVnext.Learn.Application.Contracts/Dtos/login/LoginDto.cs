using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AbpVnext.Learn.Dtos.login
{
    /// <summary>
    /// 登录的Dto
    /// </summary>
    public class LoginDto: IValidatableObject
    {
        /// <summary>
        /// 用户手机号
        /// </summary>
        [Required(ErrorMessage ="手机号码不能为空")]
        public string user_phone { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        [Required(ErrorMessage = "登录密码不能为空")]
        public string pass_word { get; set; }
        public IEnumerable<ValidationResult> Validate(
            ValidationContext validationContext)
        {
            if (user_phone == pass_word)
            {
                yield return new ValidationResult(
                    "手机号码与密码不能一样!",
                    new[] { "user_phone", "pass_word" }
                );
            }
        }
    }
}

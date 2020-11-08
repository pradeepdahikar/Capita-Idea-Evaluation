using IdeaEvaluation.Data;
using IdeaEvaluations.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdeaEvaluation.Business
{
    public class LoginService
    {
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User login(User user)
        {
            var context = new EvaluationContext();
            User userVal = new User();

            var userResult = context.Users.Where(s => s.UserName == user.UserName && s.Password == user.Password);

            if (userResult.ToList().Count > 0 && userResult.FirstOrDefault().Id > 0)
            {
                //Assign idea to judges before we redirect user to assigned ideas page
                EvaluationService evs = new EvaluationService();
                evs.AssignIdeas();
                return userResult.FirstOrDefault();
            }
            else
                return userVal;
        }
    }
}

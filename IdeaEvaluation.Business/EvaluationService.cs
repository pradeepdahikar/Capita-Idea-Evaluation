using IdeaEvaluation.Data;
using IdeaEvaluations.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace IdeaEvaluation.Business
{
    public class EvaluationService
    {
        /// <summary>
        /// Assign all the non assigned ideas to different users
        /// </summary>
        public void AssignIdeas()
        {
            var context = new EvaluationContext();
            var users = context.Users.OrderBy(x => x.Id).ToList();
            var ideas = context.Ideas;
            var mappedEvaluations = context.IdeaEvaluationMapping;
            int userCount = 0;

            List<IdeaEvaluationMapping> objectToPost = new List<IdeaEvaluationMapping>();
            //Check for ideas which are yet to be assigned
            var activeIdeaCount = ideas.Where(x => x.Assigned == false).OrderByDescending(x => x.Id).ToList();
            int totalEvaluations = 0;
            if (activeIdeaCount.Count() > 0)
                totalEvaluations = activeIdeaCount.Count * 3;

            List<int> tempEvaluatorIds = new List<int>();

            foreach (Idea _idea in activeIdeaCount)
            {
                List<int> evaluatorIds = new List<int>();
                int flagCount = 0;
                var tempUsers = users;
                foreach (IdeaEvaluationMapping _eval in mappedEvaluations)
                {
                    if (_eval.IdeaId == _idea.Id)
                    {
                        flagCount = flagCount + 1;
                        evaluatorIds.Add(_eval.EvaluationId);
                    }
                }
                if (flagCount < 3)
                {
                    for (int i = flagCount; i < 3; i++)
                    {
                        foreach (var userid in evaluatorIds)
                        {
                            var itemToRemove = tempUsers.FirstOrDefault(r => r.Id == userid);
                            tempUsers.Remove(itemToRemove);
                        }

                        if (userCount == tempUsers.Count())
                            userCount = 0;

                        objectToPost.Add(new IdeaEvaluationMapping { IdeaId = _idea.Id, EvaluationId = tempUsers.Skip(userCount).FirstOrDefault().Id });
                        userCount++;
                    }
                    //update idea assigned value to true

                    var local = context.Set<Idea>()
                                .Local
                                .FirstOrDefault(entry => entry.Id.Equals(_idea.Id));

                    // check if local is not null 
                    if (local != null)
                    {
                        // detach
                        context.Entry(local).State = EntityState.Detached;
                    }
                    // set Modified flag in your entry
                    Idea ideaToUpdate = new Idea();
                    ideaToUpdate.Assigned = true;
                    ideaToUpdate.Id = _idea.Id;
                    context.Entry(ideaToUpdate).State = EntityState.Modified;

                    
                    //context.Update(ideaToUpdate);
                    context.Entry(ideaToUpdate).Property(x => x.Id).IsModified = false;
                    context.Entry(ideaToUpdate).Property(x => x.Name).IsModified = false;
                    context.Entry(ideaToUpdate).Property(x => x.Description).IsModified = false;
                    context.Entry(ideaToUpdate).Property(x => x.Assigned).IsModified = true;
                    context.SaveChanges();
                }
            }
            var finalObject = objectToPost;
            if (finalObject.Count() > 0)
            {
                context.IdeaEvaluationMapping.AddRange(finalObject);

            }

            //Save changes to db
            context.SaveChanges();
        }

        /// <summary>
        /// Get List of ideas assigned to paricular user based on user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Idea> GetIdea(int userId)
        {
            var context = new EvaluationContext();
            var maping = context.IdeaEvaluationMapping.Where(s => s.EvaluationId == userId).ToList();

            List<Idea> lstIdea = new List<Idea>();

            foreach (IdeaEvaluationMapping idea in maping)
            {
                lstIdea.Add(context.Ideas.Where(x => x.Id == idea.IdeaId).FirstOrDefault());
            }

            return lstIdea;
        }
    }
}

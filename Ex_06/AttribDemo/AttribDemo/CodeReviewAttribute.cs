using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    class CodeReviewAttribute : Attribute
    {
        public string ReviewerName { get; private set; }
        public string ReviewDate { get; private set; }
        public bool IsApproved { get; private set; }

        public CodeReviewAttribute(string reviewerName, string reviewDate, bool isApproved)
        {
            ReviewerName = reviewerName;
            ReviewDate = reviewDate;
            IsApproved = isApproved;
        }

        public override string ToString()
        {
            return string.Format("[ CodeReview: reviewer Name : {0}, review Date : {1}, Approved : {2} ]", ReviewerName, ReviewDate, IsApproved);
        }
    }
}

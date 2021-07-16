using System;
using System.Collections.Generic;

namespace CellRepository.ApplicationService
{
    public class ApiModel<T> 
    {
        public ApiModel()
        {
            _comments = new List<string>();
        }

        public EStatusCode StatusCode { get; set; }

        public T Data { get; private set; }

        //Information for the front end
        private readonly List<string> _comments;

        public Tuple<string, bool> IsValid()
        {
            if (StatusCode == EStatusCode.NonConfigured)
                return new Tuple<string, bool>("Status Code needs to be configured", false);

            if(Data is null)
                return new Tuple<string, bool>("Data is empty", false);
            
            return new Tuple<string, bool>("OK", false);
        }

        /// <summary>
        /// Adds a new commentary in the list of comments to go to the front
        /// </summary>
        /// <param name="comment"></param>
        public void AddComment(string comment)
        {
            if (string.Empty == comment)
                return;

            _comments?.Add(comment);
        }

        /// <summary>
        /// Clears all the comment
        /// </summary>
        public void ClearComments()
        {
            _comments?.Clear();
        }

        /// <summary>
        /// Get the whole list of comments to see what's happening
        /// </summary>
        /// <returns></returns>
        public IReadOnlyCollection<string> GetComments()
        {
            return _comments?.AsReadOnly();
        }

        /// <summary>
        /// Get the whole list of comments to see what's happening
        /// </summary>
        /// <returns></returns>
        public string GetFirstComment()
        {
            return _comments.ToArray()[0];
        }

        /// <summary>
        /// Set the information
        /// </summary>
        /// <param name="data"></param>
        public void SetData(T data)
        {
            Data = data;
        }
    }
}

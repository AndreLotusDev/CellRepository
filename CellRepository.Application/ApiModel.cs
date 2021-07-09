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

        private List<string> _comments;

        public Tuple<string, bool> IsValid()
        {
            if (StatusCode == EStatusCode.NonConfigured)
                return new Tuple<string, bool>("Status Code needs to be configured", false);

            if(Data is null)
                return new Tuple<string, bool>("Data is empty", false);
            
            return new Tuple<string, bool>("OK", false);
        }

        public void AddComment(string comment)
        {
            if (string.Empty == comment)
                return;

            _comments.Add(comment);
        }

        public void ClearComments()
        {
            _comments.Clear();
        }

        public IReadOnlyCollection<string> GetComments()
        {
            return _comments.AsReadOnly();
        }

        public void SetData(T data)
        {
            Data = data;
        }
    }
}

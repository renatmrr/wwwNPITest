﻿namespace JSTable.Model
{
    public record DesignObject (int Id, string Code,string Name, int Level);
  
    public record JsProjectCompany
    {
        public JsProjectCompany (int id, string code, string name, 
            IEnumerable<DesignObject> designObjects)
        {
            Id = id;
            Code = code;
            Name = name;
            DesignObjects = designObjects;
        }

        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }


        private IEnumerable<DesignObject> DesignObjects { get; set; } = null!;

        public IEnumerable< IGrouping<int, DesignObject>> GDesignObjects => 
            DesignObjects.OrderBy(l=>l.Level).GroupBy(l => l.Level);
    }

}

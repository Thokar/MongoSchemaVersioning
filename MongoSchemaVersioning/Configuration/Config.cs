using System;
using System.Collections.Generic;
using System.Text;

namespace MongoSchemaVersioning.Configuration
{
  public class Config
  {
    public enum Feature { Feature1, Feature2};

    public Feature CurrentSet = Feature.Feature1;

  }
}

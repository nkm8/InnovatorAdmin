using Innovator.Client;
using System;

namespace Innovator.Client.Model
{
  ///<summary>Class for the item type Hide In </summary>
  public class HideIn : Item
  {
    protected HideIn() { }
    public HideIn(ElementFactory amlContext, params object[] content) : base(amlContext, content) { }
    /// <summary>Retrieve the <c>behavior</c> property of the item</summary>
    public IProperty_Text Behavior()
    {
      return this.Property("behavior");
    }
    /// <summary>Retrieve the <c>hide_in</c> property of the item</summary>
    public IProperty_Text HideInProp()
    {
      return this.Property("hide_in");
    }
    /// <summary>Retrieve the <c>label</c> property of the item</summary>
    public IProperty_Text Label()
    {
      return this.Property("label");
    }
    /// <summary>Retrieve the <c>sort_order</c> property of the item</summary>
    public IProperty_Number SortOrder()
    {
      return this.Property("sort_order");
    }
  }
}
// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Matthew Ward" email="mrward@users.sourceforge.net"/>
//     <version>$Revision: 915 $</version>
// </file>

using System;
using System.Collections.Generic;

namespace InnovatorAdmin.Editor
{
	/// <summary>
	/// Represents the path to an xml element starting from the root of the
	/// document.
	/// </summary>
	public class XmlElementPath
	{
		private QualifiedNameCollection elements;

    public IDictionary<string, string> Namespaces { get; set; }

		public XmlElementPath()
		{
      elements = new QualifiedNameCollection();
		}
    public XmlElementPath(QualifiedName[] values)
    {
      elements = new QualifiedNameCollection(values);
    }

		/// <summary>
		/// Gets the elements specifying the path.
		/// </summary>
		/// <remarks>The order of the elements determines the path.</remarks>
		public QualifiedNameCollection Elements {
			get {
				return elements;
			}
		}

		/// <summary>
		/// Compacts the path so it only contains the elements that are from
		/// the namespace of the last element in the path.
		/// </summary>
		/// <remarks>This method is used when we need to know the path for a
		/// particular namespace and do not care about the complete path.
		/// </remarks>
		public void Compact(string namespaceUri = null)
		{
			if (elements.Count > 0) {
        namespaceUri = namespaceUri ?? Elements[Elements.Count - 1].Namespace;
        var i = 0;
        while (i < elements.Count)
        {
          if (elements[i].Namespace != namespaceUri)
          {
            elements.RemoveAt(i);
          }
          else
          {
            i++;
          }
        }
			}
		}

		/// <summary>
		/// An xml element path is considered to be equal if
		/// each path item has the same name and namespace.
		/// </summary>
		public override bool Equals(object obj) {

			if (!(obj is XmlElementPath)) return false;
			if (this == obj) return true;

			XmlElementPath rhs = (XmlElementPath)obj;
			if (elements.Count == rhs.elements.Count) {

				for (int i = 0; i < elements.Count; ++i) {
					if (!elements[i].Equals(rhs.elements[i])) {
						return false;
					}
				}
				return true;
			}

			return false;
		}

		public override int GetHashCode() {
			return elements.GetHashCode();
		}

		/// <summary>
		/// Removes elements up to and including the specified index.
		/// </summary>
		void RemoveParentElements(int index)
		{
			while (index >= 0) {
				--index;
				elements.RemoveFirst();
			}
		}

		/// <summary>
		/// Finds the first parent that does belong in the specified
		/// namespace.
		/// </summary>
		int FindNonMatchingParentElement(string namespaceUri)
		{
			int index = -1;

			if (elements.Count > 1) {
				// Start the check from the the last but one item.
				for (int i = elements.Count - 2; i >= 0; --i) {
					QualifiedName name = elements[i];
					if (name.Namespace != namespaceUri) {
						index = i;
						break;
					}
				}
			}
			return index;
		}
	}
}

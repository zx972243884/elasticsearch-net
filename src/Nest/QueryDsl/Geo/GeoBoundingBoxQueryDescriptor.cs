﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace Nest
{
	internal static class GeoBoundingBoxCondition
	{
		public static bool IsConditionless(IGeoBoundingBoxQuery self)
		{
			return self.Field.IsConditionless() 
				|| self.TopLeft.IsNullOrEmpty() 
				|| self.BottomRight.IsNullOrEmpty();
		}
	}

	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public interface IGeoBoundingBoxQuery : IFieldNameQuery
	{
		PropertyPathMarker Field { get; set; }
		
		[JsonProperty("top_left")]
		string TopLeft { get; set; }

		[JsonProperty("bottom_right")]
		string BottomRight { get; set; }
		
		[JsonProperty("type")]
		GeoExecution? Type { get; set; }
	}
	
	// TODO : Finish implementing
	public class GeoBoundingBoxQuery : PlainQuery, IGeoBoundingBoxQuery
	{
		protected override void WrapInContainer(IQueryContainer container)
		{
			container.GeoBoundingBox = this;
		}

		public PropertyPathMarker GetFieldName()
		{
			return this.Field;
		}

		public void SetFieldName(string fieldName)
		{
			this.Field = fieldName;
		}

		public string Name { get; set; }
		bool IQuery.IsConditionless { get { return GeoBoundingBoxCondition.IsConditionless(this); } }
		public PropertyPathMarker Field { get; set; }
		public string TopLeft { get; set; }
		public string BottomRight { get; set; }
		public GeoExecution? Type { get; set; }
	}

	public class GeoBoundingBoxQueryDescriptor<T> : IGeoBoundingBoxQuery where T : class
	{
		private IGeoBoundingBoxQuery Self { get { return this; } }

		bool IQuery.IsConditionless { get { return GeoBoundingBoxCondition.IsConditionless(this); } }

		string IQuery.Name { get; set; }

		PropertyPathMarker IGeoBoundingBoxQuery.Field { get; set; }

		string IGeoBoundingBoxQuery.TopLeft { get; set; }

		string IGeoBoundingBoxQuery.BottomRight { get; set; }

		GeoExecution? IGeoBoundingBoxQuery.Type { get; set; }

		public GeoBoundingBoxQueryDescriptor<T> Name (string name)
		{
			Self.Name = name;
			return this;
		}

		public GeoBoundingBoxQueryDescriptor<T> Field(string field)
		{
			Self.Field = field;
			return this;
		}

		public GeoBoundingBoxQueryDescriptor<T> Field(Expression<Func<T, object>> field)
		{
			Self.Field = field;
			return this;
		}

		public GeoBoundingBoxQueryDescriptor<T> TopLeft(string topLeft)
		{
			Self.TopLeft = topLeft;
			return this;
		}

		public GeoBoundingBoxQueryDescriptor<T> BottomRight(string bottomRight)
		{
			Self.BottomRight = bottomRight;
			return this;
		}

		public GeoBoundingBoxQueryDescriptor<T> Type(GeoExecution type)
		{
			Self.Type = type;
			return this;
		}

		public PropertyPathMarker GetFieldName()
		{
			return Self.Field;
		}

		public void SetFieldName(string fieldName)
		{
			Self.Field = fieldName;
		}
	}
}

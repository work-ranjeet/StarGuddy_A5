namespace System
{
  public static partial class ObjectExtension
  {
    /// <summary>
    /// Check if null or DbNull, 
    /// an Empty string is not null!
    /// </summary>
    /// <param name="Expr"></param>
    /// <returns></returns>
    public static Boolean IsNull(this Object Expr)
    {
      return (Expr == null || Expr == DBNull.Value);
    }



    public static Int32? ToInt32Nullable(this Object Expr)
    {
      Int32? result = null;

      if (Expr.IsNull())
        return result;

      result = Expr is Enum ? (Int32)Expr : Convert.ToInt32(Expr);

      return result;
    }


    public static Int32 ToInt32(this Object Expr, Int32 DefaultValue = 0)
    {
      Int32 result = Expr is Enum ? (Int32)Expr : ToInt32Nullable(Expr) ?? DefaultValue;

      return result;
    }
  }
}

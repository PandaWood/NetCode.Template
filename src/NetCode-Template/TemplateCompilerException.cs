using System;
using System.CodeDom.Compiler;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace NetCodeT
{
	/// <summary>
	///   This exception is used when errors occur during compilation of the template code in the
	///   application domain.
	/// </summary>
	[Serializable]
	public class TemplateCompilerException : TemplateException
	{
		/// <summary>
		///   Initializes a new instance of the <see cref="TemplateCompilerException" /> class with serialized data.
		/// </summary>
		/// <param name="info">
		///   The SerializationInfo that holds the serialized object data about the exception being thrown.
		/// </param>
		/// <param name="context">
		///   The StreamingContext that contains contextual information about the source or destination.
		/// </param>
		/// <exception cref="System.ArgumentNullException">
		///   <para><paramref name="info" /> is null.</para>
		/// </exception>
		/// <exception cref="System.Runtime.Serialization.SerializationException">
		///   <para>The class name is null or System.Exception.HResult is zero (0).</para>
		/// </exception>
		protected TemplateCompilerException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			Errors = (CompilerErrorCollection)info.GetValue("Errors", typeof(CompilerErrorCollection));
		}

		/// <summary>
		///   Initializes a new instance of the <see cref="TemplateCompilerException" /> class with a specified error message
		///   and a reference to the inner exception that is the cause of this exception.
		/// </summary>
		/// <param name="message">
		///   The error message that explains the reason for the exception.
		/// </param>
		/// <param name="innerException">
		///   The exception that is the cause of the current exception. If the innerException parameter is not a null reference
		///   (Nothing in Visual Basic), the current exception is raised in a catch block that handles the inner exception.
		/// </param>
		public TemplateCompilerException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		/// <summary>
		///   Initializes a new instance of the <see cref="TemplateCompilerException" /> class with a specified error message.
		/// </summary>
		/// <param name="message">
		///   The message that describes the error.
		/// </param>
		private TemplateCompilerException(string message)
			: base(message)
		{
		}

		/// <summary>
		///   Initializes a new instance of the <see cref="TemplateCompilerException" /> class with a specified error message.
		/// </summary>
		/// <param name="message">
		///   The message that describes the error.
		/// </param>
		/// <param name="code">
		///   The code that was compiled.
		/// </param>
		/// <param name="errors">
		///   The collection of compiler errors produced when compiling the template code.
		/// </param>
		public TemplateCompilerException(string message, string code, CompilerErrorCollection errors)
			: this(message)
		{
			Code = code;
			Errors = errors;
		}

		/// <summary>
		///   Gets the collection of errors produced when compiling the faulty template source code.
		/// </summary>
		/// <value>
		///   A <see cref="CompilerErrorCollection" /> containing the <see cref="CompilerError" />
		///   objects that indicate the cause for this <see cref="TemplateCompilerException" />.
		/// </value>
		public CompilerErrorCollection Errors
		{
			get;
		}

		/// <summary>
		///   Gets the code that contained the <see cref="Errors" />.
		/// </summary>
		/// <value>
		///   The code from the template that contains the errors.
		/// </value>
		private string Code { get; }

		#region ISerializable Members

		/// <summary>
		///   When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> with
		///   information about the exception.
		/// </summary>
		/// <param name="info">
		///   The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized
		///   object data about the exception being thrown.
		/// </param>
		/// <param name="context">
		///   The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual
		///   information about the source or destination.
		/// </param>
		/// <exception cref="T:System.ArgumentNullException">The info parameter is a null reference (Nothing in Visual Basic). </exception>
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);
			info.AddValue("Errors", Errors, typeof(CompilerErrorCollection));
		}

		#endregion
	}
}
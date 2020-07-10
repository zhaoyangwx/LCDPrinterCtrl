

<Serializable>
Public Class PrinterMessage
    Property Name As String
    Property GUID As Guid
    Property Addresses As List(Of String)
    Property Message As String
    Public Sub New()
        Addresses = New List(Of String)
    End Sub
    Public Sub New(s As String)
        Addresses = New List(Of String)
        Message = s
    End Sub
    Public Function GetSerializedText()
        Dim writer As New System.Xml.Serialization.XmlSerializer(GetType(PrinterMessage))
        Dim sb As New System.Text.StringBuilder()
        Dim t As IO.TextWriter = New IO.StringWriter(sb)
        writer.Serialize(t, Me)
        t.Close()
        Return sb.ToString
    End Function
    Public Shared Function FromXML(s As String) As PrinterMessage
        Dim reader As New System.Xml.Serialization.XmlSerializer(GetType(PrinterMessage))
        Dim t As IO.TextReader = New IO.StringReader(s)
        Return CType(reader.Deserialize(t), PrinterMessage)
    End Function
    Public Class PrinterComparer
        Implements IEqualityComparer(Of PrinterMessage)
        Public Overloads Function Equals(x As PrinterMessage, y As PrinterMessage) As Boolean Implements IEqualityComparer(Of PrinterMessage).Equals
            If x Is Nothing And y Is Nothing Then Return True
            If x Is Nothing Or y Is Nothing Then Return False
            Return x.GUID = y.GUID
        End Function

        Public Overloads Function GetHashCode(obj As PrinterMessage) As Integer Implements IEqualityComparer(Of PrinterMessage).GetHashCode
            Return obj.GUID.GetHashCode
        End Function
    End Class
End Class
<Serializable>
Public Class PrinterInfo
    Property Name As String
    Property GUID As Guid
    Property Addresses As List(Of String)
    Public Sub New()
        Addresses = New List(Of String)
    End Sub
    Public Function GetSerializedText()
        Dim writer As New System.Xml.Serialization.XmlSerializer(GetType(PrinterInfo))
        Dim sb As New System.Text.StringBuilder()
        Dim t As IO.TextWriter = New IO.StringWriter(sb)
        writer.Serialize(t, Me)
        t.Close()
        Return sb.ToString
    End Function
    Public Shared Function FromXML(s As String) As PrinterInfo
        Dim reader As New System.Xml.Serialization.XmlSerializer(GetType(PrinterInfo))
        Dim t As IO.TextReader = New IO.StringReader(s)
        Return CType(reader.Deserialize(t), PrinterInfo)
    End Function
    Public Class PrinterComparer
        Implements IEqualityComparer(Of PrinterInfo)
        Public Overloads Function Equals(x As PrinterInfo, y As PrinterInfo) As Boolean Implements IEqualityComparer(Of PrinterInfo).Equals
            If x Is Nothing And y Is Nothing Then Return True
            If x Is Nothing Or y Is Nothing Then Return False
            Return x.GUID = y.GUID
        End Function

        Public Overloads Function GetHashCode(obj As PrinterInfo) As Integer Implements IEqualityComparer(Of PrinterInfo).GetHashCode
            Return obj.GUID.GetHashCode
        End Function
    End Class
End Class
<Serializable>
Public Class ClientInfo
    Property Name As String
    Property GUID As Guid
    Property Addresses As List(Of String)
    Public Sub New()
        Addresses = New List(Of String)
    End Sub
    Public Function GetSerializedText()
        Dim writer As New System.Xml.Serialization.XmlSerializer(GetType(ClientInfo))
        Dim sb As New System.Text.StringBuilder()
        Dim t As IO.TextWriter = New IO.StringWriter(sb)
        writer.Serialize(t, Me)
        t.Close()
        Return sb.ToString
    End Function
    Public Shared Function FromXML(s As String) As ClientInfo
        Dim reader As New System.Xml.Serialization.XmlSerializer(GetType(ClientInfo))
        Dim t As IO.TextReader = New IO.StringReader(s)
        Return CType(reader.Deserialize(t), ClientInfo)
    End Function
    Public Class ClientComparer
        Implements IEqualityComparer(Of ClientInfo)
        Public Overloads Function Equals(x As ClientInfo, y As ClientInfo) As Boolean Implements IEqualityComparer(Of ClientInfo).Equals
            If x Is Nothing And y Is Nothing Then Return True
            If x Is Nothing Or y Is Nothing Then Return False
            Return x.GUID = y.GUID
        End Function

        Public Overloads Function GetHashCode(obj As ClientInfo) As Integer Implements IEqualityComparer(Of ClientInfo).GetHashCode
            Return obj.GUID.GetHashCode
        End Function
    End Class
End Class
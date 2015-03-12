#Region "�ɤJ�R�W�Ŷ�"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>�����</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  QuoTestRemarkDAL
#Region "�غc��"
        ''' <summary>
        ''' �n�i��ƾڱ��QuoTestRemarkInfo���
        ''' </summary>
        ''' <param name="QuoTestRemarkInstance">�n�ާ@��QuoTestRemarkInfo�����</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal QuoTestRemarkInstance As QuoTestRemarkInfo)
            _QuoTestRemarkInstance = QuoTestRemarkInstance
        End Sub
#End Region

#Region "�ݩ�"
        Private _QuoTestRemarkInstance As QuoTestRemarkInfo

        ''' <summary>
        ''' QuoTestRemarkInfo���
        ''' </summary>
        ''' <value></value>
        ''' <returns>QuoTestRemarkInfo</returns>
        ''' <remarks></remarks>
        Public Property QuoTestRemarkInstance() As QuoTestRemarkInfo
            Get
                Return _QuoTestRemarkInstance
            End Get
            Set(ByVal Value As QuoTestRemarkInfo)
                _QuoTestRemarkInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "QuoTestRemark_Update", _
           				QuoTestRemarkInstance.pkid, _
		QuoTestRemarkInstance.ParentID, _
		QuoTestRemarkInstance.TestRemark, _
		QuoTestRemarkInstance.Extend1, _
		QuoTestRemarkInstance.Extend2, _
		QuoTestRemarkInstance.Extend3, _
		QuoTestRemarkInstance.Extend4, _
		QuoTestRemarkInstance.Extend5, _
		QuoTestRemarkInstance.RecordCreated, _
		QuoTestRemarkInstance.RecordDeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _QuoTestRemarkInstance.pkid= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "QuoTestRemark_Insert", _
           				QuoTestRemarkInstance.pkid, _
		QuoTestRemarkInstance.ParentID, _
		QuoTestRemarkInstance.TestRemark, _
		QuoTestRemarkInstance.Extend1, _
		QuoTestRemarkInstance.Extend2, _
		QuoTestRemarkInstance.Extend3, _
		QuoTestRemarkInstance.Extend4, _
		QuoTestRemarkInstance.Extend5, _
		QuoTestRemarkInstance.RecordCreated, _
		QuoTestRemarkInstance.RecordDeleted))
	 	Return  (_QuoTestRemarkInstance.pkid> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As QuoTestRemarkInfo
		
			 Dim mInfo AS  new QuoTestRemarkInfo
			mInfo.pkid = IIf(dr.IsNull("pkid"), 0, Convert.ToInt32(dr.Item("pkid")))
			mInfo.ParentID = IIf(dr.IsNull("ParentID"), 0, Convert.ToInt32(dr.Item("ParentID")))
			mInfo.TestRemark = IIf(dr.IsNull("TestRemark"), String.Empty, Convert.ToString(dr.Item("TestRemark")))
 			mInfo.Extend1 = IIf(dr.IsNull("Extend1"), String.Empty, Convert.ToString(dr.Item("Extend1")))
 			mInfo.Extend2 = IIf(dr.IsNull("Extend2"), String.Empty, Convert.ToString(dr.Item("Extend2")))
 			mInfo.Extend3 = IIf(dr.IsNull("Extend3"), String.Empty, Convert.ToString(dr.Item("Extend3")))
 			mInfo.Extend4 = IIf(dr.IsNull("Extend4"), String.Empty, Convert.ToString(dr.Item("Extend4")))
 			mInfo.Extend5 = IIf(dr.IsNull("Extend5"), String.Empty, Convert.ToString(dr.Item("Extend5")))
 			mInfo.RecordCreated = IIf(dr.IsNull("RecordCreated"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("RecordCreated")))
			mInfo.RecordDeleted = IIf(dr.IsNull("RecordDeleted"), 0, Convert.ToInt32(dr.Item("RecordDeleted")))
		Return  mInfo
		End Function 


	#End Region

	#Region " Public method"
	     Public Function Save() As Boolean
	If Not _QuoTestRemarkInstance Is Nothing Then 
            If _QuoTestRemarkInstance.pkid=0  Then
                Return Insert()
            ElseIf _QuoTestRemarkInstance.pkid > 0 Then
                    Return Update()
                Else
                   _QuoTestRemarkInstance.pkid= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the QuoTestRemarkInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' �R�����w�O��
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"QuoTestRemark_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' ������wPKID����ҫH��
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As QuoTestRemarkInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"QuoTestRemark_GetInfoByPKID", PKID)
            Dim dt As DataTable = ds.Tables(0)

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim dr As DataRow = dt.Rows(0)

            Return TransformDr(dr)
        End Function
	    ''' <summary>
    ''' ������w���󪺰O��
    ''' </summary>
    ''' <param name="SearchString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of QuoTestRemarkInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QuoTestRemark_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mQuoTestRemark As New list(of QuoTestRemarkinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mQuoTestRemark.Add(TransformDr(dr))
            Next

            Return mQuoTestRemark
		
    End Function
    Public Shared Function GetInfoByParentPKID(ByVal ParemtPKID As Integer) As QuoTestRemarkInfo
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QuoTestRemark_GetInfoByParentPKID", ParemtPKID)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return New QuoTestRemarkInfo()
        End If

        Dim dr As DataRow = dt.Rows(0)

        Return TransformDr(dr)
    End Function
	#End Region
#End Region
End Class


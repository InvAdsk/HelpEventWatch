Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Inventor


Partial Public Class frm_Main
    Inherits Form
    Private invApp As Inventor.Application = Nothing
    Private docWinEvents As DockableWindowsEvents = Nothing
    Private appEvents As ApplicationEvents = Nothing


    Public Sub New()
        InitializeComponent()
        frm_Main.CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
        button1.Enabled = False

        Try
            ' Attempt to get a reference to a running instance of Inventor.
            invApp = CType(System.Runtime.InteropServices.Marshal.GetActiveObject("Inventor.Application"), Inventor.Application)
        Catch
            MessageBox.Show("Unable to connect to Inventor.")
            button1.Enabled = True
            Return
        End Try

        Dim docWindows As DockableWindows = invApp.UserInterfaceManager.DockableWindows

        docWinEvents = docWindows.Events
        AddHandler docWinEvents.OnHelp, AddressOf docWinEvents_OnHelp
        AddHandler docWinEvents.OnHide, AddressOf docWinEvents_OnHide
        AddHandler docWinEvents.OnShow, AddressOf docWinEvents_OnShow


        appEvents = invApp.ApplicationEvents
        AddHandler appEvents.OnActivateDocument, AddressOf appEvents_OnActivateDocument
        'AddHandler appEvents.OnActivateView, AddressOf appEvents_OnActivateView
        'AddHandler appEvents.OnActivateWebView, AddressOf appEvents_
        'AddHandler appEvents.OnActiveProjectChanged, AddressOf appEvents_
        'AddHandler appEvents.OnApplicationOptionChange, AddressOf appEvents_
        AddHandler appEvents.OnCloseDocument, AddressOf appEvents_OnCloseDocument
        'AddHandler appEvents.OnCloseView, AddressOf appEvents_
        'AddHandler appEvents.OnCloseWebView, AddressOf appEvents_
        AddHandler appEvents.OnDeactivateDocument, AddressOf appEvents_OnDeactivateDocument
        'AddHandler appEvents.OnDeactivateView, AddressOf appEvents_
        'AddHandler appEvents.OnDisplayModeChange, AddressOf appEvents_
        AddHandler appEvents.OnDocumentChange, AddressOf appEvents_OnDocumentChange
        AddHandler appEvents.OnInitializeDocument, AddressOf appEvents_OnInitializeDocument
        AddHandler appEvents.OnMigrateDocument, AddressOf appEvents_OnMigrateDocument
        'AddHandler appEvents.OnMoveApplicationWindow, AddressOf appEvents_
        'AddHandler appEvents.OnMoveView, AddressOf appEvents_
        AddHandler appEvents.OnNewDocument, AddressOf appEvents_OnNewDocument
        'AddHandler appEvents.OnNewEditObject, AddressOf appEvents_
        'AddHandler appEvents.OnNewView, AddressOf appEvents_
        'AddHandler appEvents.OnNewWebView, AddressOf appEvents_
        AddHandler appEvents.OnOpenDocument, AddressOf appEvents_OnOpenDocument
        'AddHandler appEvents.OnQuit, AddressOf appEvents_OnQuit
        'AddHandler appEvents.OnReady, AddressOf appEvents_OnReady
        'AddHandler appEvents.OnResizeApplicationWindow, AddressOf appEvents_
        'AddHandler appEvents.OnResizeView, AddressOf appEvents_
        'AddHandler appEvents.OnRestart32BitHost, AddressOf appEvent_
        AddHandler appEvents.OnSaveDocument, AddressOf appEvents_OnSaveDocument
        'AddHandler appEvents.OnTerminateDocument, AddressOf appEvents_OnTerminateDocument
        'AddHandler appEvents.OnTranslateDocument, AddressOf appEvents_OnTranslateDocument
        'AddHandler appEvents.OnWebViewAct, AddressOf appEvents_


        'Dim docWindow As DockableWindow
        'docWindow = invApp.UserInterfaceManager.DockableWindows.Add("Brian4", "BrianWindow4", "Test4")

        'docWindow.ShowTitleBar = True
        'docWindow.Visible = True
    End Sub



    Private Sub docWinEvents_OnShow(ByVal DockableWindow As DockableWindow, ByVal beforeOrAfter As EventTimingEnum, ByVal Context As NameValueMap, ByRef HandlingCode As HandlingCodeEnum)
        Log_Event("OnShow", Nothing, Nothing, beforeOrAfter, Context)
        HandlingCode = Inventor.HandlingCodeEnum.kEventNotHandled
    End Sub

    Private Sub docWinEvents_OnHide(ByVal DockableWindow As DockableWindow, ByVal beforeOrAfter As EventTimingEnum, ByVal Context As NameValueMap, ByRef HandlingCode As HandlingCodeEnum)
        Log_Event("OnHide", Nothing, Nothing, beforeOrAfter, Context)
        HandlingCode = Inventor.HandlingCodeEnum.kEventNotHandled
    End Sub

    Private Sub docWinEvents_OnHelp(ByVal DockableWindow As DockableWindow, ByVal Context As NameValueMap, ByRef HandlingCode As HandlingCodeEnum)
        Log_Event("OnHelp", Nothing, Nothing, Nothing, Context)
        HandlingCode = Inventor.HandlingCodeEnum.kEventHandled
    End Sub




    Sub appEvents_OnActivateDocument(oDoc As _Document, beforeOrAfter As EventTimingEnum, context As NameValueMap, ByRef handlingCode As HandlingCodeEnum)
        Log_Event("OnActivateDocument", oDoc, Nothing, beforeOrAfter, context)
        handlingCode = Inventor.HandlingCodeEnum.kEventNotHandled
    End Sub
    Sub appEvents_OnCloseDocument(oDoc As _Document, fullDocumentName As String, beforeOrAfter As EventTimingEnum, context As NameValueMap, ByRef handlingCode As HandlingCodeEnum)
        Log_Event("OnCloseDocument", oDoc, fullDocumentName, beforeOrAfter, context)
        handlingCode = Inventor.HandlingCodeEnum.kEventNotHandled
    End Sub
    Sub appEvents_OnDeactivateDocument(ByVal oDoc As _Document, ByVal beforeOrAfter As EventTimingEnum, ByVal context As NameValueMap, ByRef handlingCode As HandlingCodeEnum)
        Log_Event("OnDeactivateDocument", oDoc, Nothing, beforeOrAfter, context)
    End Sub
    Sub appEvents_OnDocumentChange(oDoc As _Document, beforeOrAfter As EventTimingEnum, reasonsForChange As CommandTypesEnum, context As NameValueMap, ByRef handlingCode As HandlingCodeEnum)
        Log_Event("OnDocumentChange", reasonsForChange, oDoc.FullDocumentName, beforeOrAfter, context)
        handlingCode = Inventor.HandlingCodeEnum.kEventNotHandled
    End Sub
    Sub appEvents_OnInitializeDocument(oDoc As _Document, cDocName As String, beforeOrAfter As EventTimingEnum, context As NameValueMap, ByRef handlingCode As HandlingCodeEnum)
        Log_Event("OnInitializeDocument", oDoc, cDocName, beforeOrAfter, context)
        handlingCode = Inventor.HandlingCodeEnum.kEventNotHandled
    End Sub
    Sub appEvents_OnMigrateDocument(oDoc As _Document, beforeOrAfter As EventTimingEnum, context As NameValueMap, ByRef handlingCode As HandlingCodeEnum)
        Log_Event("OnMigrateDocument", oDoc, oDoc.FullDocumentName, beforeOrAfter, context)
        handlingCode = Inventor.HandlingCodeEnum.kEventNotHandled
    End Sub
    Sub appEvents_OnNewDocument(oDoc As _Document, beforeOrAfter As EventTimingEnum, context As NameValueMap, ByRef handlingCode As HandlingCodeEnum)
        Log_Event("OnNewDocument", oDoc, "keine Parameter", beforeOrAfter, context)
        handlingCode = Inventor.HandlingCodeEnum.kEventNotHandled
    End Sub
    Sub appEvents_OnOpenDocument(oDoc As _Document, fullDocumentName As String, beforeOrAfter As EventTimingEnum, context As NameValueMap, ByRef handlingCode As HandlingCodeEnum)
        Log_Event("OnOpenDocument", oDoc, fullDocumentName, beforeOrAfter, context)
        handlingCode = Inventor.HandlingCodeEnum.kEventNotHandled
    End Sub
    Sub appEvents_OnQuit()
    End Sub
    Sub appEvents_OnReady()
    End Sub
    Sub appEvents_OnSaveDocument(oSaveDoc As _Document, beforeOrAfter As EventTimingEnum, context As NameValueMap, ByRef handlingCode As HandlingCodeEnum)
        Log_Event("OnSaveDocument", oSaveDoc, "keine Parameter", beforeOrAfter, context)
        handlingCode = Inventor.HandlingCodeEnum.kEventNotHandled
    End Sub
    Sub appEvents_OnTerminateDocument()
    End Sub
    Sub appEvents_OnTranslateDocument()
    End Sub




    ''' 
    ''' <summary>
    ''' 
    ''' Routine zum Debugen der Events
    ''' 
    ''' </summary>
    ''' <param name="lEv"></param>
    ''' <param name="cProc"></param>
    ''' <param name="oObj"></param>
    ''' <param name="fullDocumentName"></param>
    ''' <param name="beforeOrAfter"></param>
    ''' <param name="context"></param>
    Private Sub Log_Event(cProc As String,
                          oObj As Object,
                          fullDocumentName As String,
                          beforeOrAfter As EventTimingEnum,
                          context As NameValueMap)

        Dim ba1 As String = ""
        Dim ba2 As String = ""

        Dim odoc As _Document
        Dim projectObject As DesignProject
        Dim viewObject As Inventor.View
        Dim oDockableWindow As DockableWindow
        Dim fileMetadataObjects As ObjectsEnumerator

        ' Change Ursache #############################################################

        If cProc = "OnDocumentChange" Then
            Dim oCmdHlp As CommandTypesEnum = CType(oObj, CommandTypesEnum)
            Select Case oCmdHlp
                Case CommandTypesEnum.kEditMaskCmdType : ba2 = " - kEditMaskCmdType"
                Case CommandTypesEnum.kFileOperationsCmdType : ba2 = " - kFileOperationsCmdType"
                Case CommandTypesEnum.kFilePropertyEditCmdType : ba2 = " - kFilePropertyEditCmdType"
                Case CommandTypesEnum.kNonShapeEditCmdType : ba2 = " - kNonShapeEditCmdType"
                Case CommandTypesEnum.kQueryOnlyCmdType : ba2 = " - kQueryOnlyCmdType"
                Case CommandTypesEnum.kReferencesChangeCmdType : ba2 = " - kReferencesChangeCmdType"
                Case CommandTypesEnum.kSchemaChangeCmdType : ba2 = " - kSchemaChangeCmdType"
                Case CommandTypesEnum.kShapeEditCmdType : ba2 = " - kShapeEditCmdType"
                Case CommandTypesEnum.kUpdateWithReferencesCmdType : ba2 = " - kUpdateWithReferencesCmdType"
            End Select
        End If

        ' Befor / After #############################################################

        If IsNothing(beforeOrAfter) = False Then
            Select Case beforeOrAfter
                Case EventTimingEnum.kBefore : ba1 = " - kBefore"
                Case EventTimingEnum.kAfter : ba1 = " - kAfter"
                Case EventTimingEnum.kAbort : ba1 = " - kAbort"
            End Select
        End If

        listBox.Items.Add(Now.ToLocalTime.ToLongTimeString)
        If IsNothing(fullDocumentName) Then
            listBox.Items.Add(cProc + ba1 + ba2)
        Else
            listBox.Items.Add(cProc + ba1 + ba2 + "  -  " + fullDocumentName)
        End If


        Dim cSpace As String = "   "

        If IsNothing(oObj) = False Then


            ' oDocs #############################################################

            If oObj.GetType Is GetType(_Document) Then
                odoc = oObj
                If IsNothing(odoc) = False Then
                    Try
                        listBox.Items.Add(cSpace + odoc.DisplayName)
                        listBox.Items.Add(cSpace + odoc.FullFileName)
                    Catch ex As Exception
                        listBox.Items.Add(cSpace + ex.Message)
                        listBox.Items.Add(cSpace + ex.StackTrace)
                    End Try
                End If
            End If

            ' projectObject #############################################################

            If oObj.GetType Is GetType(DesignProject) Then
                projectObject = oObj
                If IsNothing(projectObject) = False Then
                    Try
                        'listBox.Items.Add( "DesignProject", projectObject.DisplayName)
                        listBox.Items.Add(cSpace + "DesignProject  :  " + projectObject.FullFileName)
                    Catch ex As Exception
                        listBox.Items.Add(cSpace + "DesignProject EX" + ex.Message)
                        listBox.Items.Add(cSpace + "DesignProject EX" + ex.StackTrace)
                    End Try
                End If
            End If

            ' projectObject #############################################################

            If oObj.GetType Is GetType(Inventor.View) Then
                viewObject = oObj
                If IsNothing(viewObject) = False Then
                    Try
                        listBox.Items.Add(cSpace + "viewObject  :  " + viewObject.Caption)
                    Catch ex As Exception
                        listBox.Items.Add(cSpace + "viewObject EX " + ex.Message)
                        listBox.Items.Add(cSpace + "viewObject EX " + ex.StackTrace)
                    End Try
                End If
            End If
            ' oDockableWindow #############################################################

            If oObj.GetType Is GetType(DockableWindow) Then
                oDockableWindow = oObj
                If IsNothing(oDockableWindow) = False Then
                    Try
                        listBox.Items.Add(cSpace + "DockableWindow  :  " + oDockableWindow.Caption)
                    Catch ex As Exception
                        listBox.Items.Add(cSpace + "DockableWindow EX" + ex.Message)
                        listBox.Items.Add(cSpace + "DockableWindow EX" + ex.StackTrace)
                    End Try
                End If
            End If

            ' FileMetadataObjects #############################################################

            If oObj.GetType Is GetType(ObjectsEnumerator) Then
                fileMetadataObjects = oObj
                If IsNothing(fileMetadataObjects) = False Then
                    Try
                        For Each oMetaData In fileMetadataObjects
                            listBox.Items.Add(cSpace + "FileMetadataObjects  :  " + oMetaData.DisplayName)
                            listBox.Items.Add(cSpace + "FileMetadataObjects  :  " + oMetaData.FileName)
                        Next oMetaData
                    Catch ex As Exception
                        listBox.Items.Add(cSpace + "FileMetadataObjects EX" + ex.Message)
                        listBox.Items.Add(cSpace + "FileMetadataObjects EX" + ex.StackTrace)
                    End Try
                End If
            End If
        End If

        ' fullDocumentName #############################################################

        If IsNothing(fullDocumentName) = False Then
            Try
                listBox.Items.Add(cSpace + "fullDocumentName  :  " + fullDocumentName)
            Catch ex As Exception
                listBox.Items.Add(cSpace + "fullDocumentName EX" + ex.Message)
                listBox.Items.Add(cSpace + "fullDocumentName EX" + ex.StackTrace)
            End Try
        End If

        ' context #############################################################

        If IsNothing(context) = False Then
            Try
                Dim i As Long = 0
                For Each xx In context
                    listBox.Items.Add(cSpace + "context(" + i.ToString + ")  :  " + xx.ToString)
                    i = i + 1
                Next
            Catch ex As Exception
                listBox.Items.Add(cSpace + "context" + ex.Message)
                listBox.Items.Add(cSpace + "context" + ex.StackTrace)
            End Try
        End If

        listBox.Items.Add(" ")

    End Sub


End Class


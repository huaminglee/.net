
  update OutFileManage set eFlowDocID ='00000000-0000-0000-0000-000000000000',IsFinish =1,StateName ='完成狀態',StateOrder =3,
   IsHasFile =1,Extend1 ='',Extend2 ='',Extend3 ='',Extend4 ='',Extend5 ='',Extend6 ='',Extend7 ='',Extend8 ='',Extend9 ='',Extend10 =''
   update OutFileManage set FileVersion ='' where FileVersion is null
   update OutFileManage set FileNum =0 where FileNum is null 
   update OutFileManage set UseFor ='' where UseFor is null
   update OutFileManage set  UseForEquip ='' where UseForEquip is null
   update OutFileManage set  FileSource ='' where FileSource is null 
   update OutFileManage set BuyTime ='1900-1-1' where BuyTime is null
   update OutFileManage set BackAddress ='' where BackAddress is null
   update OutFileManage set Remark ='' where Remark is null 
   update OutFileManage set SaveType =1 where SaveType is null
   update OutFileManage set FilePageNum =1 where FilePageNum is null
   update OutFileManage set QyLocation ='E11' where QyLocation is null
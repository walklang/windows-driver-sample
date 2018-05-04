///////////////////////////////////////////////////////////////////////////////
//
//    (C) Copyright 2011 EaseFilter Technologies Inc.
//    All Rights Reserved
//
//    This software is part of a licensed software product and may
//    only be used or copied in accordance with the terms of that license.
//
///////////////////////////////////////////////////////////////////////////////

#pragma once

// Defines for NTSTATUS
typedef long NTSTATUS;

void 
ControlFilterUnitTest();

LARGE_INTEGER
GetTestFileTime();

WCHAR*
GetTestReparseFileName();

WCHAR*
GetFilterMask();

CHAR*
GetReplaceData();

LONGLONG
GetTestFileSize();

BOOL
IsTestFolder(WCHAR* fileName );

BOOL
IsTestFile(WCHAR* fileName,ULONG fileNameLength );


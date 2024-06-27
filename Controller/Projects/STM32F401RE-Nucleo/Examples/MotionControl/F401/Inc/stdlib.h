/*
 * stdlib.h
 *
 * Definitions for common types, variables, and functions.
 *
 * This file is part of the Mingw32 package.
 *
 * Contributors:
 *  Created by Colin Peters <colin@bird.fu.is.saga-u.ac.jp>
 *
 *  THIS SOFTWARE IS NOT COPYRIGHTED
 *
 *  This source code is offered for use in the public domain. You may
 *  use, modify or distribute it freely.
 *
 *  This code is distributed in the hope that it will be useful but
 *  WITHOUT ANY WARRANTY. ALL WARRANTIES, EXPRESS OR IMPLIED ARE HEREBY
 *  DISCLAMED. This includes but is not limited to warranties of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 *
 * $Revision: 1.16 $
 * $Author: khan $
 * $Date: 1999/06/15 00:47:30 $
 *
 */

#ifndef _STDLIB_H_
#define _STDLIB_H_

/* All the headers include this file. */
#include <_mingw.h>


#define __need_size_t
#define __need_wchar_t
#define __need_NULL
#ifndef RC_INVOKED
#include <stddef.h>
#endif /* RC_INVOKED */

/*
 * RAND_MAX is the maximum value that may be returned by rand.
 * The minimum is zero.
 */
#define	RAND_MAX	0x7FFF

/*
 * These values may be used as exit status codes.
 */
#define	EXIT_SUCCESS	0
#define	EXIT_FAILURE	-1

/*
 * Definitions for path name functions.
 * NOTE: All of these values have simply been chosen to be conservatively high.
 *       Remember that with long file names we can no longer depend on
 *       extensions being short.
 */
#ifndef __STRICT_ANSI__

#ifndef MAX_PATH
#define	MAX_PATH	(260)
#endif

#define	_MAX_PATH	MAX_PATH
#define	_MAX_DRIVE	(3)
#define	_MAX_DIR	256
#define	_MAX_FNAME	256
#define	_MAX_EXT	256

#endif	/* Not __STRICT_ANSI__ */


#ifndef RC_INVOKED

#ifdef __cplusplus
extern "C" {
#endif

/*
 * This seems like a convenient place to declare these variables, which
 * give programs using WinMain (or main for that matter) access to main-ish
 * argc and argv. environ is a pointer to a table of environment variables.
 * NOTE: Strings in _argv and environ are ANSI strings.
 */
extern int	_argc;
extern char**	_argv;

/* imports from runtime dll of the above variables */
#ifdef __MSVCRT__

extern int*     __p___argc(void);
extern char***   __p___argv(void);
extern wchar_t***   __p___wargv(void);

#define __argc (*__p___argc())
#define __argv (*__p___argv())
#define __wargv (*__p___wargv())

#else /* !MSVCRT */

#ifndef __DECLSPEC_SUPPORTED

extern int*    __imp___argc_dll;
extern char***  __imp___argv_dll;
#define __argc (*__imp___argc_dll)
#define __argv (*__imp___argv_dll)

#else /* __DECLSPEC_SUPPORTED */

__MINGW_IMPORT int    __argc_dll;
__MINGW_IMPORT char**  __argv_dll;
#define __argc __argc_dll
#define __argv __argv_dll

#endif /* __DECLSPEC_SUPPORTED */

#endif /* __MSVCRT */

/* 
 * MS likes to declare errno in stdlib.h as well. 
 */

#ifdef _UWIN
#undef errno
extern int errno;
#else
int*	_errno();
#define	errno		(*_errno())
#endif
int*	__doserrno();
#define	_doserrno	(*__doserrno())

/*
 * Use environ from the DLL, not as a global. 
 */

#ifdef __MSVCRT__
  extern char *** __p__environ();
  extern wchar_t *** __p__wenviron();
# define _environ (*__p__environ())
# define _wenviron (*__p__wenviron())
#else /* ! __MSVCRT__ */
# ifndef __DECLSPEC_SUPPORTED
    extern char *** __imp__environ_dll;
#   define _environ (*__imp__environ_dll)
# else /* __DECLSPEC_SUPPORTED */
    __MINGW_IMPORT char ** _environ_dll;
#   define _environ _environ_dll
# endif /* __DECLSPEC_SUPPORTED */
#endif /* ! __MSVCRT__ */

#define environ _environ

#ifdef	__MSVCRT__
/* One of the MSVCRTxx libraries */

#ifndef __DECLSPEC_SUPPORTED
  extern int*	__imp__sys_nerr;
# define	sys_nerr	(*__imp__sys_nerr)
#else /* __DECLSPEC_SUPPORTED */
  __MINGW_IMPORT int	_sys_nerr;
# ifndef _UWIN
#   define	sys_nerr	_sys_nerr
# endif /* _UWIN */
#endif /* __DECLSPEC_SUPPORTED */

#else /* ! __MSVCRT__ */

/* CRTDLL run time library */

#ifndef __DECLSPEC_SUPPORTED
  extern int*	__imp__sys_nerr_dll;
# define sys_nerr	(*__imp__sys_nerr_dll)
#else /* __DECLSPEC_SUPPORTED */
  __MINGW_IMPORT int	_sys_nerr_dll;
# define sys_nerr	_sys_nerr_dll
#endif /* __DECLSPEC_SUPPORTED */

#endif /* ! __MSVCRT__ */

#ifndef __DECLSPEC_SUPPORTED
extern char***	__imp__sys_errlist;
#define	sys_errlist	(*__imp__sys_errlist)
#else /* __DECLSPEC_SUPPORTED */
__MINGW_IMPORT char*	_sys_errlist[];
#ifndef _UWIN
#define	sys_errlist	_sys_errlist
#endif /* _UWIN */
#endif /* __DECLSPEC_SUPPORTED */

/*
 * OS version and such constants.
 */
#ifndef __STRICT_ANSI__

#ifdef	__MSVCRT__
/* msvcrtxx.dll */

extern unsigned int*	__p__osver();
extern unsigned int*	__p__winver();
extern unsigned int*	__p__winmajor();
extern unsigned int*	__p__winminor();

#define _osver		(*__p__osver())
#define _winver		(*__p__winver())
#define _winmajor	(*__p__winmajor())
#define _winminor	(*__p__winminor())

#else
/* Not msvcrtxx.dll, thus crtdll.dll */

#ifndef __DECLSPEC_SUPPORTED

extern unsigned int*	_imp___osver_dll;
extern unsigned int*	_imp___winver_dll;
extern unsigned int*	_imp___winmajor_dll;
extern unsigned int*	_imp___winminor_dll;

#define _osver		(*_imp___osver_dll)
#define _winver		(*_imp___winver_dll)
#define _winmajor	(*_imp___winmajor_dll)
#define _winminor	(*_imp___winminor_dll)

#else /* __DECLSPEC_SUPPORTED */

__MINGW_IMPORT unsigned int	_osver_dll;
__MINGW_IMPORT unsigned int	_winver_dll;
__MINGW_IMPORT unsigned int	_winmajor_dll;
__MINGW_IMPORT unsigned int	_winminor_dll;

#define _osver		_osver_dll
#define _winver		_winver_dll
#define _winmajor	_winmajor_dll
#define _winminor	_winminor_dll

#endif /* __DECLSPEC_SUPPORTED */

#endif

#endif /* Not __STRICT_ANSI__ */

#ifdef	__GNUC__
#define	_ATTRIB_NORETURN	__attribute__ ((noreturn))
#else	/* Not __GNUC__ */
#define	_ATTRIB_NORETURN
#endif	/* __GNUC__ */

double	atof	(const char* szNumber);
int	atoi	(const char* szNumber);
long	atol	(const char* szNumber);

double	strtod	(const char* szNumber, char** pszAfterNumber);
double	wcstod	(const wchar_t* wsNumber, wchar_t** pwsAfterNumber);
long	strtol	(const char* szNumber, char** pszAfterNumber, int nBase);
long	wcstol	(const wchar_t* wsNumber, wchar_t** pwsAfterNumber, int nBase);

unsigned long	strtoul	(const char* szNumber, char** pszAfterNumber,
			int nBase);
unsigned long	wcstoul (const wchar_t* wsNumber, wchar_t** pwsAfterNumber,
			int nBase);

size_t	wcstombs	(char* mbsDest, const wchar_t* wsConvert, size_t size);
int	wctomb		(char* mbDest, wchar_t wc);

int	mblen		(const char* mbs, size_t sizeString);
size_t	mbstowcs	(wchar_t* wcaDest, const char* mbsConvert,
			 size_t size);
int	mbtowc		(wchar_t* wcDest, const char* mbConvert, size_t size);

int	rand	();
void	srand	(unsigned int nSeed);

void*	calloc	(size_t sizeObjCnt, size_t sizeObject);
void*	malloc	(size_t	sizeObject);
void*	realloc	(void* pObject, size_t sizeNew);
void	free	(void* pObject);

void	abort	() _ATTRIB_NORETURN;
void	exit	(int nStatus) _ATTRIB_NORETURN;
int	atexit	(void (*pfuncExitProcessing)(void));

int	system	(const char* szCommand);
char*	getenv	(const char* szVarName);

typedef	int (*_pfunccmp_t)(const void*, const void*);

void*	bsearch	(const void* pKey, const void* pBase, size_t cntObjects,
		size_t sizeObject, _pfunccmp_t pfuncCmp);
void	qsort	(const void* pBase, size_t cntObjects, size_t sizeObject,
		_pfunccmp_t pfuncCmp);

int	abs	(int n);
long	labs	(long n);

/*
 * div_t and ldiv_t are structures used to return the results of div and
 * ldiv.
 *
 * NOTE: div and ldiv appear not to work correctly unless
 *       -fno-pcc-struct-return is specified. This is included in the
 *       mingw32 specs file.
 */
typedef struct { int quot, rem; } div_t;
typedef struct { long quot, rem; } ldiv_t;

div_t	div	(int nNumerator, int nDenominator);
ldiv_t	ldiv	(long lNumerator, long lDenominator);


#ifndef	__STRICT_ANSI__

/*
 * NOTE: Officially the three following functions are obsolete. The Win32 API
 *       functions SetErrorMode, Beep and Sleep are their replacements.
 */
void	_beep (unsigned int, unsigned int);
void	_seterrormode (int nMode);
void	_sleep (unsigned long ulTime);

void	_exit	(int nStatus) _ATTRIB_NORETURN;

int	_putenv	(const char* szNameEqValue);
void	_searchenv (const char* szFileName, const char* szVar,
		char* szFullPathBuf);

char*	_itoa (int nValue, char* sz, int nRadix);
char*	_ltoa (long lnValue, char* sz, int nRadix);

char*	_ecvt (double dValue, int nDig, int* pnDec, int* pnSign);
char*	_fcvt (double dValue, int nDig, int* pnDec, int* pnSign);
char*	_gcvt (double dValue, int nDec, char* caBuf);

void	_makepath (char* caPath, const char* szDrive, const char* szDir,
		const char* szName, const char* szExtension);
void	_splitpath (const char* szPath, char* caDrive, char* caDir,
		char* caName, char* caExtension);
char*	_fullpath (char* caBuf, const char* szPath, size_t sizeMax);
int	_wtoi (const wchar_t *);
long	_wtol (const wchar_t *);

char*	_i64toa(__int64, char *, int);
char*	_ui64toa(unsigned __int64, char *, int);
__int64	_atoi64(const char *);

wchar_t* _i64tow(__int64, wchar_t *, int);
wchar_t* _ui64tow(unsigned __int64, wchar_t *, int);
__int64	_wtoi64(const wchar_t *);


#ifndef	_NO_OLDNAMES

int	putenv (const char* szNameEqValue);
void	searchenv (const char* szFileName, const char* szVar,
		char* szFullPathBuf);

char*	itoa (int nValue, char* sz, int nRadix);
char*	ltoa (long lnValue, char* sz, int nRadix);

#ifndef _UWIN
char*	ecvt (double dValue, int nDig, int* pnDec, int* pnSign);
char*	fcvt (double dValue, int nDig, int* pnDec, int* pnSign);
char*	gcvt (double dValue, int nDec, char* caBuf);
#endif /* _UWIN */
#endif	/* Not _NO_OLDNAMES */

#endif	/* Not __STRICT_ANSI__ */

/*
 * Undefine the no return attribute used in some function definitions
 */
#undef	_ATTRIB_NORETURN

#ifdef __cplusplus
}
#endif

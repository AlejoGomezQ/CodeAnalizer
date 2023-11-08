
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                 =  0, // (EOF)
        SYMBOL_ERROR               =  1, // (Error)
        SYMBOL_WHITESPACE          =  2, // Whitespace
        SYMBOL_MINUS               =  3, // '-'
        SYMBOL_AMP                 =  4, // '&'
        SYMBOL_LPAREN              =  5, // '('
        SYMBOL_RPAREN              =  6, // ')'
        SYMBOL_TIMES               =  7, // '*'
        SYMBOL_COMMA               =  8, // ','
        SYMBOL_DIV                 =  9, // '/'
        SYMBOL_SEMI                = 10, // ';'
        SYMBOL_LBRACE              = 11, // '{'
        SYMBOL_PIPE                = 12, // '|'
        SYMBOL_RBRACE              = 13, // '}'
        SYMBOL_PLUS                = 14, // '+'
        SYMBOL_LT                  = 15, // '<'
        SYMBOL_EQ                  = 16, // '='
        SYMBOL_GT                  = 17, // '>'
        SYMBOL_BOOLEAN             = 18, // boolean
        SYMBOL_CHAR                = 19, // char
        SYMBOL_DO                  = 20, // do
        SYMBOL_DOUBLE              = 21, // double
        SYMBOL_ELSE                = 22, // else
        SYMBOL_ENTERONEGATIVO      = 23, // enteroNegativo
        SYMBOL_ENTEROPOSITIVO      = 24, // enteroPositivo
        SYMBOL_FALSE               = 25, // False
        SYMBOL_FLOAT               = 26, // float
        SYMBOL_FOR                 = 27, // for
        SYMBOL_ID                  = 28, // id
        SYMBOL_IF                  = 29, // if
        SYMBOL_INT                 = 30, // int
        SYMBOL_LONG                = 31, // long
        SYMBOL_NUM                 = 32, // num
        SYMBOL_PRINCIPAL           = 33, // Principal
        SYMBOL_REALNEGATIVO        = 34, // realNegativo
        SYMBOL_REALPOSITIVO        = 35, // realPositivo
        SYMBOL_RETORNO             = 36, // retorno
        SYMBOL_STRING              = 37, // string
        SYMBOL_TRUE                = 38, // True
        SYMBOL_VOID                = 39, // void
        SYMBOL_WHILE               = 40, // while
        SYMBOL_CONDICION           = 41, // <Condicion>
        SYMBOL_CONDICIONSIMPLE     = 42, // <CondicionSimple>
        SYMBOL_DECLARACION         = 43, // <Declaracion>
        SYMBOL_EXPRESION           = 44, // <Expresion>
        SYMBOL_FACTOR              = 45, // <Factor>
        SYMBOL_FUNCION             = 46, // <Funcion>
        SYMBOL_ID2                 = 47, // <id>
        SYMBOL_INCREMENTO          = 48, // <Incremento>
        SYMBOL_LISTADECLARACIONES  = 49, // <ListaDeclaraciones>
        SYMBOL_LISTADECLARACIONESP = 50, // <ListaDeclaracionesP>
        SYMBOL_LISTAEXPRESIONES    = 51, // <ListaExpresiones>
        SYMBOL_LISTAFUNCIONES      = 52, // <ListaFunciones>
        SYMBOL_LISTAPARAMETROS     = 53, // <ListaParametros>
        SYMBOL_LISTAPROCEDIMIENTOS = 54, // <ListaProcedimientos>
        SYMBOL_LISTASENTENCIAS     = 55, // <ListaSentencias>
        SYMBOL_LLAMADAFUNCION      = 56, // <LlamadaFuncion>
        SYMBOL_PROCEDIMIENTO       = 57, // <Procedimiento>
        SYMBOL_PROGRAMA            = 58, // <Programa>
        SYMBOL_SENTENCIA           = 59, // <Sentencia>
        SYMBOL_SENTENCIAASIGNACION = 60, // <SentenciaAsignacion>
        SYMBOL_SENTENCIADOWHILE    = 61, // <SentenciaDoWhile>
        SYMBOL_SENTENCIAFOR        = 62, // <SentenciaFor>
        SYMBOL_SENTENCIAIF         = 63, // <SentenciaIf>
        SYMBOL_SENTENCIAWHILE      = 64, // <SentenciaWhile>
        SYMBOL_TERMINO             = 65, // <Termino>
        SYMBOL_TIPODATO            = 66  // <TipoDato>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAMA_PRINCIPAL_LBRACE_RBRACE                              =  0, // <Programa> ::= Principal '{' <ListaDeclaraciones> <ListaSentencias> '}'
        RULE_PROGRAMA_PRINCIPAL_LBRACE_RBRACE2                             =  1, // <Programa> ::= Principal '{' <ListaDeclaraciones> <ListaSentencias> '}' <ListaFunciones>
        RULE_PROGRAMA_PRINCIPAL_LBRACE_RBRACE3                             =  2, // <Programa> ::= Principal '{' <ListaDeclaraciones> <ListaSentencias> '}' <ListaProcedimientos>
        RULE_PROGRAMA_PRINCIPAL_LBRACE_RBRACE4                             =  3, // <Programa> ::= Principal '{' <ListaDeclaraciones> <ListaSentencias> '}' <ListaFunciones> <ListaProcedimientos>
        RULE_PROGRAMA_PRINCIPAL_LBRACE_RBRACE5                             =  4, // <Programa> ::= Principal '{' <ListaDeclaraciones> <ListaSentencias> '}' <ListaProcedimientos> <ListaFunciones>
        RULE_LISTADECLARACIONES                                            =  5, // <ListaDeclaraciones> ::= <ListaDeclaracionesP>
        RULE_LISTADECLARACIONESP                                           =  6, // <ListaDeclaracionesP> ::= <Declaracion> <ListaDeclaracionesP>
        RULE_LISTADECLARACIONESP2                                          =  7, // <ListaDeclaracionesP> ::= 
        RULE_DECLARACION_SEMI                                              =  8, // <Declaracion> ::= <TipoDato> <id> ';'
        RULE_DECLARACION_EQ_SEMI                                           =  9, // <Declaracion> ::= <TipoDato> <id> '=' <Expresion> ';'
        RULE_LISTAFUNCIONES                                                = 10, // <ListaFunciones> ::= <ListaFunciones> <Funcion>
        RULE_LISTAFUNCIONES2                                               = 11, // <ListaFunciones> ::= <Funcion>
        RULE_LISTASENTENCIAS                                               = 12, // <ListaSentencias> ::= <ListaSentencias> <Sentencia>
        RULE_LISTASENTENCIAS2                                              = 13, // <ListaSentencias> ::= <Sentencia>
        RULE_LISTAPROCEDIMIENTOS                                           = 14, // <ListaProcedimientos> ::= <ListaProcedimientos> <Procedimiento>
        RULE_LISTAPROCEDIMIENTOS2                                          = 15, // <ListaProcedimientos> ::= <Procedimiento>
        RULE_FUNCION_LPAREN_RPAREN_LBRACE_RETORNO_SEMI_RBRACE              = 16, // <Funcion> ::= <TipoDato> <id> '(' <ListaParametros> ')' '{' <ListaSentencias> retorno <Expresion> ';' '}'
        RULE_FUNCION_VOID_LPAREN_RPAREN_LBRACE_RBRACE                      = 17, // <Funcion> ::= void <id> '(' <ListaParametros> ')' '{' <ListaSentencias> '}'
        RULE_PROCEDIMIENTO_VOID_LPAREN_RPAREN_LBRACE_RBRACE                = 18, // <Procedimiento> ::= void <id> '(' ')' '{' <ListaSentencias> '}'
        RULE_SENTENCIA                                                     = 19, // <Sentencia> ::= <SentenciaAsignacion>
        RULE_SENTENCIA2                                                    = 20, // <Sentencia> ::= <SentenciaFor>
        RULE_SENTENCIA3                                                    = 21, // <Sentencia> ::= <SentenciaWhile>
        RULE_SENTENCIA4                                                    = 22, // <Sentencia> ::= <SentenciaDoWhile>
        RULE_SENTENCIA5                                                    = 23, // <Sentencia> ::= <SentenciaIf>
        RULE_SENTENCIA6                                                    = 24, // <Sentencia> ::= <LlamadaFuncion>
        RULE_SENTENCIAASIGNACION_EQ_SEMI                                   = 25, // <SentenciaAsignacion> ::= <id> '=' <Expresion> ';'
        RULE_SENTENCIAFOR_FOR_LPAREN_SEMI_RPAREN_LBRACE_RBRACE             = 26, // <SentenciaFor> ::= for '(' <SentenciaAsignacion> <Condicion> ';' <Incremento> ')' '{' <ListaSentencias> '}'
        RULE_INCREMENTO_ID_PLUS_PLUS                                       = 27, // <Incremento> ::= id '+' '+'
        RULE_SENTENCIAWHILE_WHILE_LPAREN_RPAREN_LBRACE_RBRACE              = 28, // <SentenciaWhile> ::= while '(' <Condicion> ')' '{' <ListaSentencias> '}'
        RULE_SENTENCIADOWHILE_DO_LBRACE_RBRACE_WHILE_LPAREN_RPAREN         = 29, // <SentenciaDoWhile> ::= do '{' <ListaSentencias> '}' while '(' <Condicion> ')'
        RULE_SENTENCIAIF_IF_LPAREN_RPAREN_LBRACE_RBRACE                    = 30, // <SentenciaIf> ::= if '(' <Condicion> ')' '{' <ListaSentencias> '}'
        RULE_SENTENCIAIF_IF_LPAREN_RPAREN_LBRACE_RBRACE_ELSE_LBRACE_RBRACE = 31, // <SentenciaIf> ::= if '(' <Condicion> ')' '{' <ListaSentencias> '}' else '{' <ListaSentencias> '}'
        RULE_LLAMADAFUNCION_LPAREN_RPAREN_SEMI                             = 32, // <LlamadaFuncion> ::= <id> '(' <ListaExpresiones> ')' ';'
        RULE_TIPODATO_INT                                                  = 33, // <TipoDato> ::= int
        RULE_TIPODATO_CHAR                                                 = 34, // <TipoDato> ::= char
        RULE_TIPODATO_STRING                                               = 35, // <TipoDato> ::= string
        RULE_TIPODATO_DOUBLE                                               = 36, // <TipoDato> ::= double
        RULE_TIPODATO_FLOAT                                                = 37, // <TipoDato> ::= float
        RULE_TIPODATO_LONG                                                 = 38, // <TipoDato> ::= long
        RULE_TIPODATO_BOOLEAN                                              = 39, // <TipoDato> ::= boolean
        RULE_LISTAPARAMETROS_COMMA                                         = 40, // <ListaParametros> ::= <ListaParametros> ',' <TipoDato> <id>
        RULE_LISTAPARAMETROS                                               = 41, // <ListaParametros> ::= <TipoDato> <id>
        RULE_LISTAEXPRESIONES_COMMA                                        = 42, // <ListaExpresiones> ::= <ListaExpresiones> ',' <Expresion>
        RULE_LISTAEXPRESIONES                                              = 43, // <ListaExpresiones> ::= <Expresion>
        RULE_EXPRESION_PLUS                                                = 44, // <Expresion> ::= <Expresion> '+' <Termino>
        RULE_EXPRESION_MINUS                                               = 45, // <Expresion> ::= <Expresion> '-' <Termino>
        RULE_EXPRESION                                                     = 46, // <Expresion> ::= <Termino>
        RULE_TERMINO_TIMES                                                 = 47, // <Termino> ::= <Termino> '*' <Factor>
        RULE_TERMINO_DIV                                                   = 48, // <Termino> ::= <Termino> '/' <Factor>
        RULE_TERMINO                                                       = 49, // <Termino> ::= <Factor>
        RULE_FACTOR_LPAREN_RPAREN                                          = 50, // <Factor> ::= '(' <Expresion> ')'
        RULE_FACTOR                                                        = 51, // <Factor> ::= <id>
        RULE_CONDICION_AMP_AMP                                             = 52, // <Condicion> ::= <Condicion> '&' '&' <CondicionSimple>
        RULE_CONDICION_PIPE_PIPE                                           = 53, // <Condicion> ::= <Condicion> '|' '|' <CondicionSimple>
        RULE_CONDICION                                                     = 54, // <Condicion> ::= <CondicionSimple>
        RULE_CONDICIONSIMPLE_LT                                            = 55, // <CondicionSimple> ::= <Expresion> '<' <Expresion>
        RULE_CONDICIONSIMPLE_GT                                            = 56, // <CondicionSimple> ::= <Expresion> '>' <Expresion>
        RULE_CONDICIONSIMPLE_LT_EQ                                         = 57, // <CondicionSimple> ::= <Expresion> '<' '=' <Expresion>
        RULE_CONDICIONSIMPLE_GT_EQ                                         = 58, // <CondicionSimple> ::= <Expresion> '>' '=' <Expresion>
        RULE_CONDICIONSIMPLE_EQ_EQ                                         = 59, // <CondicionSimple> ::= <Expresion> '=' '=' <Expresion>
        RULE_CONDICIONSIMPLE_LPAREN_RPAREN                                 = 60, // <CondicionSimple> ::= '(' <Condicion> ')'
        RULE_CONDICIONSIMPLE_TRUE                                          = 61, // <CondicionSimple> ::= True
        RULE_CONDICIONSIMPLE_FALSE                                         = 62, // <CondicionSimple> ::= False
        RULE_ID_NUM                                                        = 63, // <id> ::= num
        RULE_ID_ID                                                         = 64  // <id> ::= id
    };

    public class MyParser
    {
        private LALRParser parser;

        public static String cadena;

        public String getCadena()
        {
            return cadena;
        }

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AMP :
                //'&'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PIPE :
                //'|'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BOOLEAN :
                //boolean
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CHAR :
                //char
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOUBLE :
                //double
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ENTERONEGATIVO :
                //enteroNegativo
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ENTEROPOSITIVO :
                //enteroPositivo
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FALSE :
                //False
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //float
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LONG :
                //long
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NUM :
                //num
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRINCIPAL :
                //Principal
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_REALNEGATIVO :
                //realNegativo
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_REALPOSITIVO :
                //realPositivo
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETORNO :
                //retorno
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TRUE :
                //True
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VOID :
                //void
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONDICION :
                //<Condicion>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONDICIONSIMPLE :
                //<CondicionSimple>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DECLARACION :
                //<Declaracion>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESION :
                //<Expresion>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<Factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCION :
                //<Funcion>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID2 :
                //<id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INCREMENTO :
                //<Incremento>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LISTADECLARACIONES :
                //<ListaDeclaraciones>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LISTADECLARACIONESP :
                //<ListaDeclaracionesP>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LISTAEXPRESIONES :
                //<ListaExpresiones>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LISTAFUNCIONES :
                //<ListaFunciones>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LISTAPARAMETROS :
                //<ListaParametros>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LISTAPROCEDIMIENTOS :
                //<ListaProcedimientos>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LISTASENTENCIAS :
                //<ListaSentencias>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LLAMADAFUNCION :
                //<LlamadaFuncion>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROCEDIMIENTO :
                //<Procedimiento>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAMA :
                //<Programa>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SENTENCIA :
                //<Sentencia>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SENTENCIAASIGNACION :
                //<SentenciaAsignacion>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SENTENCIADOWHILE :
                //<SentenciaDoWhile>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SENTENCIAFOR :
                //<SentenciaFor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SENTENCIAIF :
                //<SentenciaIf>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SENTENCIAWHILE :
                //<SentenciaWhile>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERMINO :
                //<Termino>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIPODATO :
                //<TipoDato>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAMA_PRINCIPAL_LBRACE_RBRACE :
                //<Programa> ::= Principal '{' <ListaDeclaraciones> <ListaSentencias> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROGRAMA_PRINCIPAL_LBRACE_RBRACE2 :
                //<Programa> ::= Principal '{' <ListaDeclaraciones> <ListaSentencias> '}' <ListaFunciones>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROGRAMA_PRINCIPAL_LBRACE_RBRACE3 :
                //<Programa> ::= Principal '{' <ListaDeclaraciones> <ListaSentencias> '}' <ListaProcedimientos>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROGRAMA_PRINCIPAL_LBRACE_RBRACE4 :
                //<Programa> ::= Principal '{' <ListaDeclaraciones> <ListaSentencias> '}' <ListaFunciones> <ListaProcedimientos>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROGRAMA_PRINCIPAL_LBRACE_RBRACE5 :
                //<Programa> ::= Principal '{' <ListaDeclaraciones> <ListaSentencias> '}' <ListaProcedimientos> <ListaFunciones>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LISTADECLARACIONES :
                //<ListaDeclaraciones> ::= <ListaDeclaracionesP>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LISTADECLARACIONESP :
                //<ListaDeclaracionesP> ::= <Declaracion> <ListaDeclaracionesP>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LISTADECLARACIONESP2 :
                //<ListaDeclaracionesP> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DECLARACION_SEMI :
                //<Declaracion> ::= <TipoDato> <id> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DECLARACION_EQ_SEMI :
                //<Declaracion> ::= <TipoDato> <id> '=' <Expresion> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LISTAFUNCIONES :
                //<ListaFunciones> ::= <ListaFunciones> <Funcion>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LISTAFUNCIONES2 :
                //<ListaFunciones> ::= <Funcion>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LISTASENTENCIAS :
                //<ListaSentencias> ::= <ListaSentencias> <Sentencia>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LISTASENTENCIAS2 :
                //<ListaSentencias> ::= <Sentencia>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LISTAPROCEDIMIENTOS :
                //<ListaProcedimientos> ::= <ListaProcedimientos> <Procedimiento>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LISTAPROCEDIMIENTOS2 :
                //<ListaProcedimientos> ::= <Procedimiento>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCION_LPAREN_RPAREN_LBRACE_RETORNO_SEMI_RBRACE :
                //<Funcion> ::= <TipoDato> <id> '(' <ListaParametros> ')' '{' <ListaSentencias> retorno <Expresion> ';' '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCION_VOID_LPAREN_RPAREN_LBRACE_RBRACE :
                //<Funcion> ::= void <id> '(' <ListaParametros> ')' '{' <ListaSentencias> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROCEDIMIENTO_VOID_LPAREN_RPAREN_LBRACE_RBRACE :
                //<Procedimiento> ::= void <id> '(' ')' '{' <ListaSentencias> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA :
                //<Sentencia> ::= <SentenciaAsignacion>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA2 :
                //<Sentencia> ::= <SentenciaFor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA3 :
                //<Sentencia> ::= <SentenciaWhile>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA4 :
                //<Sentencia> ::= <SentenciaDoWhile>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA5 :
                //<Sentencia> ::= <SentenciaIf>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA6 :
                //<Sentencia> ::= <LlamadaFuncion>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAASIGNACION_EQ_SEMI :
                //<SentenciaAsignacion> ::= <id> '=' <Expresion> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAFOR_FOR_LPAREN_SEMI_RPAREN_LBRACE_RBRACE :
                //<SentenciaFor> ::= for '(' <SentenciaAsignacion> <Condicion> ';' <Incremento> ')' '{' <ListaSentencias> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INCREMENTO_ID_PLUS_PLUS :
                //<Incremento> ::= id '+' '+'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAWHILE_WHILE_LPAREN_RPAREN_LBRACE_RBRACE :
                //<SentenciaWhile> ::= while '(' <Condicion> ')' '{' <ListaSentencias> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SENTENCIADOWHILE_DO_LBRACE_RBRACE_WHILE_LPAREN_RPAREN :
                //<SentenciaDoWhile> ::= do '{' <ListaSentencias> '}' while '(' <Condicion> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAIF_IF_LPAREN_RPAREN_LBRACE_RBRACE :
                //<SentenciaIf> ::= if '(' <Condicion> ')' '{' <ListaSentencias> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAIF_IF_LPAREN_RPAREN_LBRACE_RBRACE_ELSE_LBRACE_RBRACE :
                //<SentenciaIf> ::= if '(' <Condicion> ')' '{' <ListaSentencias> '}' else '{' <ListaSentencias> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LLAMADAFUNCION_LPAREN_RPAREN_SEMI :
                //<LlamadaFuncion> ::= <id> '(' <ListaExpresiones> ')' ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TIPODATO_INT :
                //<TipoDato> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TIPODATO_CHAR :
                //<TipoDato> ::= char
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TIPODATO_STRING :
                //<TipoDato> ::= string
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TIPODATO_DOUBLE :
                //<TipoDato> ::= double
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TIPODATO_FLOAT :
                //<TipoDato> ::= float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TIPODATO_LONG :
                //<TipoDato> ::= long
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TIPODATO_BOOLEAN :
                //<TipoDato> ::= boolean
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LISTAPARAMETROS_COMMA :
                //<ListaParametros> ::= <ListaParametros> ',' <TipoDato> <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LISTAPARAMETROS :
                //<ListaParametros> ::= <TipoDato> <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LISTAEXPRESIONES_COMMA :
                //<ListaExpresiones> ::= <ListaExpresiones> ',' <Expresion>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LISTAEXPRESIONES :
                //<ListaExpresiones> ::= <Expresion>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESION_PLUS :
                //<Expresion> ::= <Expresion> '+' <Termino>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESION_MINUS :
                //<Expresion> ::= <Expresion> '-' <Termino>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESION :
                //<Expresion> ::= <Termino>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERMINO_TIMES :
                //<Termino> ::= <Termino> '*' <Factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERMINO_DIV :
                //<Termino> ::= <Termino> '/' <Factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERMINO :
                //<Termino> ::= <Factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_LPAREN_RPAREN :
                //<Factor> ::= '(' <Expresion> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<Factor> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDICION_AMP_AMP :
                //<Condicion> ::= <Condicion> '&' '&' <CondicionSimple>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDICION_PIPE_PIPE :
                //<Condicion> ::= <Condicion> '|' '|' <CondicionSimple>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDICION :
                //<Condicion> ::= <CondicionSimple>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDICIONSIMPLE_LT :
                //<CondicionSimple> ::= <Expresion> '<' <Expresion>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDICIONSIMPLE_GT :
                //<CondicionSimple> ::= <Expresion> '>' <Expresion>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDICIONSIMPLE_LT_EQ :
                //<CondicionSimple> ::= <Expresion> '<' '=' <Expresion>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDICIONSIMPLE_GT_EQ :
                //<CondicionSimple> ::= <Expresion> '>' '=' <Expresion>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDICIONSIMPLE_EQ_EQ :
                //<CondicionSimple> ::= <Expresion> '=' '=' <Expresion>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDICIONSIMPLE_LPAREN_RPAREN :
                //<CondicionSimple> ::= '(' <Condicion> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDICIONSIMPLE_TRUE :
                //<CondicionSimple> ::= True
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDICIONSIMPLE_FALSE :
                //<CondicionSimple> ::= False
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_NUM :
                //<id> ::= num
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_ID :
                //<id> ::= id
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void ReduceEvent(LALRParser parser, ReduceEventArgs args)
        {
            try
            {
                args.Token.UserObject = CreateObject(args.Token);
            }
            catch (Exception e)
            {
                args.Continue = false;
            }
        }

        private void TokenReadEvent(LALRParser parser, TokenReadEventArgs args)
        {
            try
            {
                args.Token.UserObject = CreateObject(args.Token);
            }
            catch (Exception e)
            {
                args.Continue = false;
            }
        }

        private void AcceptEvent(LALRParser parser, AcceptEventArgs args)
        {
            System.Windows.Forms.MessageBox.Show("El código ha sido analizado correctamente");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
        }

    }
}

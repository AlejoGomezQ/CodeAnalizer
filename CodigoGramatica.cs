
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
        SYMBOL_EXPRESION           = 43, // <Expresion>
        SYMBOL_FACTOR              = 44, // <Factor>
        SYMBOL_FUNCION             = 45, // <Funcion>
        SYMBOL_ID2                 = 46, // <id>
        SYMBOL_INCREMENTO          = 47, // <Incremento>
        SYMBOL_LISTAEXPRESIONES    = 48, // <ListaExpresiones>
        SYMBOL_LISTAFUNCIONES      = 49, // <ListaFunciones>
        SYMBOL_LISTAPARAMETROS     = 50, // <ListaParametros>
        SYMBOL_LISTAPROCEDIMIENTOS = 51, // <ListaProcedimientos>
        SYMBOL_LISTASENTENCIAS     = 52, // <ListaSentencias>
        SYMBOL_LLAMADAFUNCION      = 53, // <LlamadaFuncion>
        SYMBOL_PROCEDIMIENTO       = 54, // <Procedimiento>
        SYMBOL_PROGRAMA            = 55, // <Programa>
        SYMBOL_SENTENCIA           = 56, // <Sentencia>
        SYMBOL_SENTENCIAASIGNACION = 57, // <SentenciaAsignacion>
        SYMBOL_SENTENCIADOWHILE    = 58, // <SentenciaDoWhile>
        SYMBOL_SENTENCIAFOR        = 59, // <SentenciaFor>
        SYMBOL_SENTENCIAIF         = 60, // <SentenciaIf>
        SYMBOL_SENTENCIAWHILE      = 61, // <SentenciaWhile>
        SYMBOL_TERMINO             = 62, // <Termino>
        SYMBOL_TIPODATO            = 63  // <TipoDato>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAMA_PRINCIPAL_LBRACE_RBRACE                              =  0, // <Programa> ::= Principal '{' <ListaSentencias> '}'
        RULE_PROGRAMA_PRINCIPAL_LBRACE_RBRACE2                             =  1, // <Programa> ::= Principal '{' <ListaSentencias> '}' <ListaFunciones>
        RULE_PROGRAMA_PRINCIPAL_LBRACE_RBRACE3                             =  2, // <Programa> ::= Principal '{' <ListaSentencias> '}' <ListaProcedimientos>
        RULE_PROGRAMA_PRINCIPAL_LBRACE_RBRACE4                             =  3, // <Programa> ::= Principal '{' <ListaSentencias> '}' <ListaFunciones> <ListaProcedimientos>
        RULE_PROGRAMA_PRINCIPAL_LBRACE_RBRACE5                             =  4, // <Programa> ::= Principal '{' <ListaSentencias> '}' <ListaProcedimientos> <ListaFunciones>
        RULE_LISTAFUNCIONES                                                =  5, // <ListaFunciones> ::= <ListaFunciones> <Funcion>
        RULE_LISTAFUNCIONES2                                               =  6, // <ListaFunciones> ::= <Funcion>
        RULE_LISTASENTENCIAS                                               =  7, // <ListaSentencias> ::= <ListaSentencias> <Sentencia>
        RULE_LISTASENTENCIAS2                                              =  8, // <ListaSentencias> ::= <Sentencia>
        RULE_LISTAPROCEDIMIENTOS                                           =  9, // <ListaProcedimientos> ::= <ListaProcedimientos> <Procedimiento>
        RULE_LISTAPROCEDIMIENTOS2                                          = 10, // <ListaProcedimientos> ::= <Procedimiento>
        RULE_FUNCION_LPAREN_RPAREN_LBRACE_RETORNO_SEMI_RBRACE              = 11, // <Funcion> ::= <TipoDato> <id> '(' <ListaParametros> ')' '{' <ListaSentencias> retorno <Expresion> ';' '}'
        RULE_FUNCION_VOID_LPAREN_RPAREN_LBRACE_RBRACE                      = 12, // <Funcion> ::= void <id> '(' <ListaParametros> ')' '{' <ListaSentencias> '}'
        RULE_PROCEDIMIENTO_VOID_LPAREN_RPAREN_LBRACE_RBRACE                = 13, // <Procedimiento> ::= void <id> '(' ')' '{' <ListaSentencias> '}'
        RULE_SENTENCIA                                                     = 14, // <Sentencia> ::= <SentenciaAsignacion>
        RULE_SENTENCIA2                                                    = 15, // <Sentencia> ::= <SentenciaFor>
        RULE_SENTENCIA3                                                    = 16, // <Sentencia> ::= <SentenciaWhile>
        RULE_SENTENCIA4                                                    = 17, // <Sentencia> ::= <SentenciaDoWhile>
        RULE_SENTENCIA5                                                    = 18, // <Sentencia> ::= <SentenciaIf>
        RULE_SENTENCIA6                                                    = 19, // <Sentencia> ::= <LlamadaFuncion>
        RULE_SENTENCIAASIGNACION_EQ_SEMI                                   = 20, // <SentenciaAsignacion> ::= <id> '=' <Expresion> ';'
        RULE_SENTENCIAFOR_FOR_LPAREN_SEMI_RPAREN_LBRACE_RBRACE             = 21, // <SentenciaFor> ::= for '(' <SentenciaAsignacion> <Condicion> ';' <Incremento> ')' '{' <ListaSentencias> '}'
        RULE_INCREMENTO_ID_PLUS_PLUS                                       = 22, // <Incremento> ::= id '+' '+'
        RULE_SENTENCIAWHILE_WHILE_LPAREN_RPAREN_LBRACE_RBRACE              = 23, // <SentenciaWhile> ::= while '(' <Condicion> ')' '{' <ListaSentencias> '}'
        RULE_SENTENCIADOWHILE_DO_LBRACE_RBRACE_WHILE_LPAREN_RPAREN         = 24, // <SentenciaDoWhile> ::= do '{' <ListaSentencias> '}' while '(' <Condicion> ')'
        RULE_SENTENCIAIF_IF_LPAREN_RPAREN_LBRACE_RBRACE                    = 25, // <SentenciaIf> ::= if '(' <Condicion> ')' '{' <ListaSentencias> '}'
        RULE_SENTENCIAIF_IF_LPAREN_RPAREN_LBRACE_RBRACE_ELSE_LBRACE_RBRACE = 26, // <SentenciaIf> ::= if '(' <Condicion> ')' '{' <ListaSentencias> '}' else '{' <ListaSentencias> '}'
        RULE_LLAMADAFUNCION_LPAREN_RPAREN_SEMI                             = 27, // <LlamadaFuncion> ::= <id> '(' <ListaExpresiones> ')' ';'
        RULE_TIPODATO_INT                                                  = 28, // <TipoDato> ::= int
        RULE_TIPODATO_CHAR                                                 = 29, // <TipoDato> ::= char
        RULE_TIPODATO_STRING                                               = 30, // <TipoDato> ::= string
        RULE_TIPODATO_DOUBLE                                               = 31, // <TipoDato> ::= double
        RULE_TIPODATO_FLOAT                                                = 32, // <TipoDato> ::= float
        RULE_TIPODATO_LONG                                                 = 33, // <TipoDato> ::= long
        RULE_TIPODATO_BOOLEAN                                              = 34, // <TipoDato> ::= boolean
        RULE_LISTAPARAMETROS_COMMA                                         = 35, // <ListaParametros> ::= <ListaParametros> ',' <TipoDato> <id>
        RULE_LISTAPARAMETROS                                               = 36, // <ListaParametros> ::= <TipoDato> <id>
        RULE_LISTAEXPRESIONES_COMMA                                        = 37, // <ListaExpresiones> ::= <ListaExpresiones> ',' <Expresion>
        RULE_LISTAEXPRESIONES                                              = 38, // <ListaExpresiones> ::= <Expresion>
        RULE_EXPRESION_PLUS                                                = 39, // <Expresion> ::= <Expresion> '+' <Termino>
        RULE_EXPRESION_MINUS                                               = 40, // <Expresion> ::= <Expresion> '-' <Termino>
        RULE_EXPRESION                                                     = 41, // <Expresion> ::= <Termino>
        RULE_TERMINO_TIMES                                                 = 42, // <Termino> ::= <Termino> '*' <Factor>
        RULE_TERMINO_DIV                                                   = 43, // <Termino> ::= <Termino> '/' <Factor>
        RULE_TERMINO                                                       = 44, // <Termino> ::= <Factor>
        RULE_FACTOR_LPAREN_RPAREN                                          = 45, // <Factor> ::= '(' <Expresion> ')'
        RULE_FACTOR                                                        = 46, // <Factor> ::= <id>
        RULE_CONDICION_AMP_AMP                                             = 47, // <Condicion> ::= <Condicion> '&' '&' <CondicionSimple>
        RULE_CONDICION_PIPE_PIPE                                           = 48, // <Condicion> ::= <Condicion> '|' '|' <CondicionSimple>
        RULE_CONDICION                                                     = 49, // <Condicion> ::= <CondicionSimple>
        RULE_CONDICIONSIMPLE_LT                                            = 50, // <CondicionSimple> ::= <Expresion> '<' <Expresion>
        RULE_CONDICIONSIMPLE_GT                                            = 51, // <CondicionSimple> ::= <Expresion> '>' <Expresion>
        RULE_CONDICIONSIMPLE_LT_EQ                                         = 52, // <CondicionSimple> ::= <Expresion> '<' '=' <Expresion>
        RULE_CONDICIONSIMPLE_GT_EQ                                         = 53, // <CondicionSimple> ::= <Expresion> '>' '=' <Expresion>
        RULE_CONDICIONSIMPLE_EQ_EQ                                         = 54, // <CondicionSimple> ::= <Expresion> '=' '=' <Expresion>
        RULE_CONDICIONSIMPLE_LPAREN_RPAREN                                 = 55, // <CondicionSimple> ::= '(' <Condicion> ')'
        RULE_CONDICIONSIMPLE_TRUE                                          = 56, // <CondicionSimple> ::= True
        RULE_CONDICIONSIMPLE_FALSE                                         = 57, // <CondicionSimple> ::= False
        RULE_ID_NUM                                                        = 58, // <id> ::= num
        RULE_ID_ID                                                         = 59  // <id> ::= id
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

            parser.OnReduce += new LALRParser.ReduceHandler(ReduceEvent);
            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
            parser.OnAccept += new LALRParser.AcceptHandler(AcceptEvent);

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
                //<Programa> ::= Principal '{' <ListaSentencias> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROGRAMA_PRINCIPAL_LBRACE_RBRACE2 :
                //<Programa> ::= Principal '{' <ListaSentencias> '}' <ListaFunciones>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROGRAMA_PRINCIPAL_LBRACE_RBRACE3 :
                //<Programa> ::= Principal '{' <ListaSentencias> '}' <ListaProcedimientos>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROGRAMA_PRINCIPAL_LBRACE_RBRACE4 :
                //<Programa> ::= Principal '{' <ListaSentencias> '}' <ListaFunciones> <ListaProcedimientos>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROGRAMA_PRINCIPAL_LBRACE_RBRACE5 :
                //<Programa> ::= Principal '{' <ListaSentencias> '}' <ListaProcedimientos> <ListaFunciones>
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

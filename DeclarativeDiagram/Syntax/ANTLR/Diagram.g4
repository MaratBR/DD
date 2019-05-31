grammar Diagram;

code: (( WS | '\n' )* ( stmt ('\n' | <EOF> | ';') | comment ) )* (WS | '\n')*;

stmt: define;
comment: '#--' .*? '--#' | '#' ~'\n'*? ('\n' | <EOF>);
functionCall: IDENTIFIER WS* '(' functionArgs ')';
functionArgs: (WS* compoundExpr WS* ( ',' WS* compoundExpr WS* )* )?;
functionArgsDefinition: (WS* IDENTIFIER WS* ( ',' WS* IDENTIFIER WS* )* )?;

define: DEF WS+ IDENTIFIER ( WS* '(' functionArgsDefinition ')' )? WS* '=' WS* compoundExpr;

expression: number | '(' WS* compoundExpr WS* ')' | IDENTIFIER;

compoundExpr
    : expression
    | powerOp
    | productOp
    | addOp
    | functionCall
    ;

addOp: addOp WS* ADD_OP WS* addOp | productOp;
productOp: productOp WS* PRODUCT_OP WS* productOp | powerOp;
powerOp: powerOp WS* POWER_OP WS* powerOp | expression;


number
	: HEX_NUMBER
	| OCT_NUMBER
	| BIN_NUMBER
	| DEC_NUMBER
	;

/*
 * Lexer Rules
 */

DEC_NUMBER : ZERO | (NON_ZERO_DIGIT DIGIT* | ZERO) ('.' DIGIT+)? EXP?;
HEX_NUMBER : ZERO 'x' HEX_DIGIT+;
OCT_NUMBER : ZERO 'o' OCT_DIGIT+;
BIN_NUMBER : ZERO 'b' BIN_DIGIT+;

PRINT: 'print';
DEF: 'def';
IDENTIFIER: LETTER (LETTER | DIGIT)*;
LETTER: 'a' .. 'z' | 'A' .. 'Z' | '_';
ADD_OP: '+' | '-';
PRODUCT_OP: '*' | '/' | '%' | '//';
POWER_OP: '**';
WS: ' ' | '\t' | '\r' | '\\\n';


fragment EXP : ('e' | 'E') (ZERO | ('+' | '-')? NON_ZERO_DIGIT DIGIT*);
fragment NON_ZERO_DIGIT : '1' .. '9';
fragment OCT_DIGIT : '0' .. '7';
fragment HEX_DIGIT : '0' .. '9' | 'a' .. 'f' | 'A' .. 'F';
fragment BIN_DIGIT : '0' | '1';
fragment DIGIT : '0' .. '9';
fragment ZERO: '0';




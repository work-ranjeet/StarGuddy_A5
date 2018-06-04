
interface StringConstructor {
    Empty: string;
    isNullOrEmpty: (val: any) => boolean;
}


String.Empty = "";  

String.isNullOrEmpty = function (val: any): boolean {
    return (val === undefined || val === null || val.trim() === '');
};
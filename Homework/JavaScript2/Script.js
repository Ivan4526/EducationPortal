class Shape {
    Square(a) {

    }
}
class Circle extends Shape {
    Square(r) {
        return pi * r * r;
    }
}
class Square extends Shape {
    Square(a) {
        return a * a;
    }
}
let user = {
    name: "John",
    age: 30,
    isAdmin: true
};
function getProperties(myObject = user) {
    var o = "";
    for (key in myObject) {
        o += key + " ";
    }
    alert(o);
    Object.getOwnPropertyNames(myObject).filter(function (p) {
        alert(typeof myObject[p] === 'function');
    });
}
function getKeyValuePair(myObject = user) {
    var keyValuePairs = "";
    for (key in myObject) {
        keyValuePairs += key + " - " + myObject[key] + "; ";
    }
    alert(keyValuePairs)
}
class Validator {
    isValid() {
        alert("Not implemented")
    }
}
class EmailValidator extends Validator {
    isValid() {
        alert("EmailValidator not implemented");
    }
}
class PhoneValidator extends Validator {
    isValid() {
        alert("PhoneValidator not implemented");
    }
}
function ShowValidator() {
    let obj = new Validator();
    obj.isValid();
}
function ShowEmailValidator(email) {
    let obj = new EmailValidator();
    obj.isValid();

    alert("Validating value from input:" + email);
}
function ShowPhoneValidator(phone) {
    let obj = new PhoneValidator();
    obj.isValid();

    alert("Validating value from input:" + phone)
}
function submitForm() {
    debugger;
    var emailElement = document.getElementById("Email");
    var phoneElement = document.getElementById("Phone");
    ShowEmailValidator(emailElement.value);
    ShowPhoneValidator(phoneElement.value);
}
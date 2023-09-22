class Passport:
    def __init__(self, first_name: str,last_name:str, date_of_birth:str, passport_number: str, country:str) -> None:
        self.first_name = first_name
        self.last_name = last_name
        self.date_of_birth = date_of_birth
        self.passport_number = passport_number
        self.country = country
    def __str__(self) -> str:
        return f"First name: {self.first_name}\nLast name: {self.last_name}\nDate of birth: {self.date_of_birth}\nCountry: {self.country}"
    
class ForeignPassport(Passport):
    def __init__(self, first_name: str, last_name: str, date_of_birth: str, passport_number: str, country: str, foreign_passport_number:str) -> None:
        super().__init__(first_name, last_name, date_of_birth, passport_number, country)
        self.foreign_passport_number = foreign_passport_number
        self.visas = []
    
    def __str__(self) -> str:
        return super().__str__()
    
    def add_visa(self, visa):
        return  self.visas.append(visa) 

    def display_info(self)->str:
        print( f"First name: {self.first_name}\nLast name: {self.last_name}\nDate of birth: {self.date_of_birth}\nCountry: {self.country}\nForeign passport number: {self.foreign_passport_number}\n************\nVisas: \n\t{self.visas}")

class Visa(ForeignPassport):
    def __init__(self, Vcountry: str, date:str) -> None:
        self.country = Vcountry
        self.date = date
    def __str__(self) -> str:
        return f"[{self.country}] [{self.date}]"

if __name__ == "__main__":
    passport = Passport("Nurzhan", "Seisenbay", "15.07.2004", "221892", "Kazakhstan")
    fpassport = ForeignPassport(passport.first_name, passport.last_name,passport.date_of_birth,passport.passport_number, passport.country, "1827318")

    visa = Visa("A", "15.09.2020")

    fpassport.add_visa(visa.__str__())

    fpassport.display_info()

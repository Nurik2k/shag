from libs.database import *
from libs.record import *

if __name__ == "__main__":
    Database.record_class = Record

    db = Database()
    db.records.append(Record(['John Doe', '25', 'Male']))
    db.records.append(Record(['Jane Doe', '30', 'Female']))

    for record in db.records:
        print(record)
export interface ResRequest {
    data: Datum[];
}

export interface Datum {
    id:            number;
    user:          string;
    name:          string;
    password:      string;
    typeUser:      string;
    vacationsList: VacationsList[];
    absencesList:  AbsencesList[];
}

interface AbsencesList {
    reason:    string;
    startdate: Date;
    enddate:   Date;
    day:       Date;
    username:  null;
    id:        number;
}

interface VacationsList {
    reason:    string;
    startdate: Date;
    enddate:   Date;
    comment:   string;
    id:        number;
}

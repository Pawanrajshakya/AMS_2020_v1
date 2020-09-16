export interface IState {
  name: string;
  shortName: string;
}

export function getState(): IState[] {
  const states: IState[] = [
    { name: "Alabama", shortName: "AL" },
    { name: "Alaska", shortName: "AK" },
    { name: "Arizona", shortName: "AZ" },
    { name: "Arkansas", shortName: "AR" },
    { name: "California", shortName: "CA" },
    { name: "Colorado", shortName: "CO" },
    { name: "Connecticut", shortName: "CT" },
    { name: "Delaware", shortName: "DE" },
    { name: "Florida", shortName: "FL" },
    { name: "Georgia", shortName: "GA" },
    { name: "Hawaii", shortName: "HI" },
    { name: "Idaho", shortName: "ID" },
    { name: "Illinois", shortName: "IL" },
    { name: "Indiana", shortName: "IN" },
    { name: "Iowa", shortName: "IA" },
    { name: "Kansas", shortName: "KS" },
    { name: "Kentucky", shortName: "KY" },
    { name: "Louisiana", shortName: "LA" },
    { name: "Maine", shortName: "ME" },
    { name: "Maryland", shortName: "MD" },
    { name: "Massachusetts", shortName: "MA" },
    { name: "Michigan", shortName: "MI" },
    { name: "Minnesota", shortName: "MN" },
    { name: "Mississippi", shortName: "MS" },
    { name: "Missouri", shortName: "MO" },
    { name: "Montana", shortName: "MT" },
    { name: "Nebraska", shortName: "NE" },
    { name: "Nevada", shortName: "NV" },
    { name: "New Hampshire", shortName: "NH" },
    { name: "New Jersey", shortName: "NJ" },
    { name: "New Mexico", shortName: "NM" },
    { name: "New York", shortName: "NY" },
    { name: "North Carolina", shortName: "NC" },
    { name: "North Dakota", shortName: "ND" },
    { name: "Ohio", shortName: "OH" },
    { name: "Oklahoma", shortName: "OK" },
    { name: "Oregon", shortName: "OR" },
    { name: "Pennsylvania", shortName: "PA" },
    { name: "Rhode Island", shortName: "RI" },
    { name: "South Carolina", shortName: "SC" },
    { name: "South Dakota", shortName: "SD" },
    { name: "Tennessee", shortName: "TN" },
    { name: "Texas", shortName: "TX" },
    { name: "Utah", shortName: "UT" },
    { name: "Vermont", shortName: "VT" },
    { name: "Virginia", shortName: "VA" },
    { name: "Washington", shortName: "WA" },
    { name: "West Virginia", shortName: "WV" },
    { name: "Wisconsin", shortName: "WI" },
    { name: "Wyoming", shortName: "WY" }
  ];

  return states;
}
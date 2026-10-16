import { combineReducers } from "redux";
import auth from "./auth";
import message from "./message";
import fundraiser from "./fundraiser";
import fundraiserType from "./fundraiser.type";
import category from "./category";
import organisation from "./organisation";
import currency from "./currency";

export default combineReducers({
  auth,
  message,
  fundraiser,
  fundraiserType,
  category,
  organisation,
  currency,
});
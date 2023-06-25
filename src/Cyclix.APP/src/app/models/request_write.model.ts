import {Customer} from "./customer.model";

export interface RequestWrite {
  typeId?: number
  brandId?: number
  serviceId?: number
  packageIds?: number[]
  optionIds?: number[]
  anotherOptionIds?: number[]
  description?: string
  note?: string
  customer?: Customer
}

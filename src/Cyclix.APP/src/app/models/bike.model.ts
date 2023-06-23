import {Customer} from "./customer.model";

export interface Bike {
  typeId?: number
  brandId?: number
  serviceId?: number
  packageId?: number[]
  optionId?: number[]
  anotherOptionId?: number[]
  description?: string
  note?: string
  customer?: Customer
}

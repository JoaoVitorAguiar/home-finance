import { api } from "@/services/api"
import type { TotalsByPersonResponse } from "@/types/report"

export class ReportsService {
    static async getTotalsByPerson(): Promise<TotalsByPersonResponse> {
        const { data } = await api.get<TotalsByPersonResponse>("/reports/by-person")
        return data
    }
}